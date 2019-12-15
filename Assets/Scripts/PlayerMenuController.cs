using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 5f;


    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private Collider2D coll;
    private bool movement = true;
    public bool playPressed = false;


    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();

        animator.SetFloat("yPosition", rb.transform.position.y);
        animator.SetBool("grounded", true);
        animator.SetBool("standing", false);
        animator.SetBool("running", true);


    }
    void FixedUpdate()
    {
        if (transform.position.x < -5)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            animator.SetBool("running", true);

        }
        else
        {
            rb.velocity = new Vector2(0, 0);

            if (playPressed) { animator.SetBool("standing", true); }
            else
            {
                animator.SetBool("running", false);
                animator.SetBool("standing", false);
            }

        }

        animator.SetFloat("speed", rb.velocity.x);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("yPosition", rb.transform.position.y);


    }

    void Update()
    {


    }

}
