 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;       // Player movement speed
    public float jumpForce = 10f;   // Player jump force
    public float groundCheckDistance = 0.1f;
    private Rigidbody2D rb;        // Player rigidbody
    public Animator animator;      // Player animator
    public bool isGrounded;        // Is the player on the ground?
    public bool isJumping;         // Is the player jumping?

    public Transform groundCheckCollider;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public bool isAttacking;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for left and right arrow keys
        isAttacking = animator.GetBool("isAttacking");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Move the player left or right
        transform.position += new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;
        if (!isJumping&&!isAttacking){
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));}
        animator.SetFloat("jump", rb.velocity.y);

        // Rotate the player left or right based on movement direction
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Check for jump key
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Update jumping animation
       
    }

    void FixedUpdate()
    {
        GroundCheck();
       
    }

    void GroundCheck()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheckCollider.position, groundCheckRadius, groundLayer);
        isJumping = !isGrounded;
         animator.SetBool("isJumping", isJumping);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckCollider.position, groundCheckRadius);
    } 
}