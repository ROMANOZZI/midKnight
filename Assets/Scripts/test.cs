using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float moveSpeed = 2f;
    public LayerMask barrierLayer;
    public float checkDistance = 0.5f;

    private Rigidbody2D rb;
    private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirection());
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movementDirection, checkDistance, barrierLayer);

        if (hit.collider != null)
        {
            ChangeDirectionImmediately();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    void ChangeDirectionImmediately()
    {
        movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
