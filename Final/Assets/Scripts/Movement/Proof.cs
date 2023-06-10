using UnityEngine;

public class Proof : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalMovement;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, whatIsGround);

        horizontalMovement = Input.GetAxisRaw("Horizontal2") * movementSpeed;

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (horizontalMovement < 0 && facingRight)
        {
            Flip();
        }
        else if (horizontalMovement > 0 && !facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}