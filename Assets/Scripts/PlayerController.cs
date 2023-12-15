using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private Transform groundDetect;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private float jumpPower;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 move;

    void Start()
    {
        // Get references to components
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        UpdateAnimation();
    }

    void Move()
    {
        // Read input for movement
        move.x = Input.GetAxis("Horizontal");
        //move.y = Input.GetAxis("Vertical");

        // Check for jump input
        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            // Apply jump power when on the ground
            myRB.velocity = new Vector2(myRB.velocity.x, jumpPower);
        }
        else if (Input.GetButtonUp("Jump") && myRB.velocity.y > 0f)
        {
            // Limit upward movement by reducing the vertical velocity
            myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.9f);
        }

        // Translate the player based on input and speed
        transform.Translate(move * runSpeed * Time.deltaTime);

        // Flip the sprite based on the horizontal movement
        FlipSprite();
    }

    void UpdateAnimation()
    {
        // Determine if the player is moving
        bool isMoving = Mathf.Abs(move.x) > 0.01f || Mathf.Abs(move.y) > 0.01f;

        // Set animator parameters
        animator.SetBool("isMoving", isMoving);

        // Play appropriate animations based on the player's state
        if (IsOnGround())
        {
            animator.Play(isMoving ? "PlayerRun" : "PlayerIdle");
        }
        else
        {
            animator.Play("PlayerJump");
        }
    }

    void FlipSprite()
    {
        // Flip the sprite based on the horizontal movement
        if (move.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (move.x < -0.01f)
            spriteRenderer.flipX = true;
    }

    private bool IsOnGround()
    {
        // Check if the player is on the ground using a circle overlap
        return Physics2D.OverlapCircle(groundDetect.position, 0.2f, groundLayer);
    }
}
