using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;       // Player movement speed
    public float jumpForce = 5f;   // Player jump force

    private Rigidbody2D rb;        // Player rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
{
    // Check for left and right arrow keys
    float horizontalInput = Input.GetAxisRaw("Horizontal");

    // Move the player left or right
    transform.position += new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;

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
    if (Input.GetKeyDown(KeyCode.Space))
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
}

