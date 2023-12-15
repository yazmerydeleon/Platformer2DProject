using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text crystalPointsText;
    private int crystalCollectedPoints;
    private int playerLives = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCollectedCrystalPoints()
    {
        crystalCollectedPoints += Random.Range(1, 10);
        crystalPointsText.text= crystalCollectedPoints.ToString();
        Debug.Log("crystalCollectedPoints");
    }
    public void DecreasePlayerLives()
    {

    }
}
