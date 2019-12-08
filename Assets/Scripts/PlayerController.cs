using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 5f;

    [SerializeField] private float jumpVelocity = 5f;

    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private Collider2D coll;

    private bool isJumping = false;
    protected bool dead = false;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
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
        // if player is dead, reset the game 
        // TODO: Trigger game over.
        if (dead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void setDead(bool value)
    {
        dead = value;
    }


    private void handleJumping()
    {

        if (Physics2D.IsTouchingLayers(coll, groundLayer))
        {
            isJumping = false;
        }

        // Start the jump sequence.
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
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
        animator.SetBool("grounded", !isJumping);
        animator.SetFloat("yVelocity", rb.velocity.y);


    }
}
