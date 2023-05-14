using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightAttack : MonoBehaviour
{
    public Animator playerAnim;
    public float attackDelay;
    public GameObject weapon;
    public float attackRange;
    public int attackDamage;
    public LayerMask enemyLayer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown ("Fire1"))
        {
           playerAnim.SetBool("isAttacking", true);
          
        }
        
        }
        public void Attack()
        {
          
            Collider2D[] enemies = Physics2D.OverlapCircleAll(weapon.transform.position, attackRange, enemyLayer);
            if (enemies.Length > 0){
             foreach (Collider2D item in enemies)
             {
                 Debug.Log("hit" + item.name);
                 item.GetComponent<enemyHealth>().TakeDamage(attackDamage);
             }}
           
        }
            
public  void endAttack()
 {
     playerAnim.SetBool("isAttacking", false);
 }  
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(weapon.transform.position, attackRange);
    }
}
