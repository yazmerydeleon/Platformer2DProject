using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    private Animator animator;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
       gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("isCollected", true);
       
        if (gameManager != null)
        {
            gameManager.IncreaseCollectedCrystalPoints();
        }
        Destroy(gameObject);
        

    }
}
