using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision occurred with the player or a specific object
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            collision.gameObject.GetComponent<enemyHealth>().TakeDamage(20);
            Debug.Log("hit");
        }



        
    }
}
