using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 5f;

    [SerializeField] private float jumpVelocity = 10f;

    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private Collider2D coll;
    public bool dead = false;
    private bool movement = true;


    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();


        animator.SetBool("running", true);
        animator.SetFloat("yPosition", rb.transform.position.y);
        animator.SetBool("grounded", true);


    }
    void FixedUpdate()
    {
        if (movement) { rb.velocity = new Vector2(maxSpeed, rb.velocity.y); }
        else { rb.velocity = new Vector2(0, rb.velocity.y); }




        // if player is falling, make it fall faster
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            // rb.AddForce(new Vector2(0, Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime), ForceMode2D.Force);
        }
        // if the player is jumping and holding the jump button,
        // make the player jump slightly higher (Mario style)
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        animator.SetFloat("speed", rb.velocity.x);

        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("yPosition", rb.transform.position.y);


    }

    void Update()
    {
        bool grounded = IsGrounded();

        animator.SetBool("grounded", grounded);
        // Start the jump sequence if character is not jumping
        if (!dead && grounded && Input.GetKeyDown(KeyCode.Space))
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);

        }
    }


    private bool IsGrounded()
    {
        float extraHeightTest = .5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraHeightTest, groundLayer);

        return raycastHit.collider != null;
    }

    public void SetMovement(bool val) { movement = val; }
}
