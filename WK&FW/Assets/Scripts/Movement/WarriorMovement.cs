using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f; // Velocidad de movimiento
    [SerializeField] private float jumpForce = 10f; // Fuerza del salto
    [SerializeField] private float groundCheckRadius = 0.2f; // Radio del círculo para comprobar si está en el suelo
    [SerializeField] private LayerMask whatIsGround; // Capa que representa el suelo
    [SerializeField] private Animator playerAnimator;

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
        
        horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;
        
        // Animator receives the informatiom about the position of the warrior
        playerAnimator.SetBool("isGrounded", isGrounded);
        
        // The knight is falling if his y-axis velocity is negative
        playerAnimator.SetFloat("AirSpeedY", rb.velocity.y);
        
        // Is the warrior running?
        if (Mathf.Abs(horizontalMovement) != 0)
        {
            playerAnimator.SetInteger("AnimState", 1);
        }
        else
        {
            playerAnimator.SetInteger("AnimState", 0);
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAnimator.SetTrigger("Jump");
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
