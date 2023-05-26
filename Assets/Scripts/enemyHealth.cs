using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;public Animator enemy;
    public void TakeDamage(int damage)
    {   
        health -= damage;
        enemy.SetBool("hitted", true);
        if (health <= 0)
        {
            
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void endHit()
    {
        enemy.SetBool("hitted", false);
    }
   
}
