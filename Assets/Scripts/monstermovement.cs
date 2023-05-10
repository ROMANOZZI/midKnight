using UnityEngine;

public class monstermovement : MonoBehaviour
{

    public float speed = 5f; // The speed at which the monster moves
    private int direction = 1; // The direction in which the monster is moving (1 for right, -1 for left)
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private Rigidbody2D rb2d; // Reference to the Rigidbody2D component

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Get the Rigidbody2D component
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move the monster in its current direction
        rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);

        // Flip the monster sprite if it's moving left
        if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Change the direction of the monster to the opposite direction
        direction *= -1;
    }
}