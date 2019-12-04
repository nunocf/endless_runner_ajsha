using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float moveSpeed = 5f;
    public float maxSpeed = 5f;

    public float jumpVelocity = 5f;
    private Rigidbody2D rb;
    private Collider2D coll;

    private bool grounded;
    public LayerMask groundLayer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        animator.SetBool("started", true);
    }
    void FixedUpdate()
    {
        if (rb.velocity.x <= maxSpeed) { rb.AddForce(new Vector2(moveSpeed, 0)); }
        else { rb.velocity = new Vector2(maxSpeed, rb.velocity.y); }
    }

    void Update()
    {

        handleJumping();
        handleDeath();
    }

    private void handleDeath()
    {
        // if player falls, reset the game 
        // TODO: Trigger game over.
        if (transform.position.y < -8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void handleJumping()
    {
        grounded = Physics2D.IsTouchingLayers(coll, groundLayer);
        // Start the jump sequence.
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);

        }

        // if player is falling, make it fall faster
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // if the player is jumping and holding the jump button,
        // make the player jump slightly higher (Mario style)
        else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        animator.SetFloat("speed", rb.velocity.x);
        animator.SetBool("grounded", grounded);
        animator.SetFloat("yVelocity", rb.velocity.y);


    }
}
