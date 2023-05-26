using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCombat : MonoBehaviour
{
    public Animator GobAnim;
    public GameObject weapon;
    public float attackRange = 0.5f;
    public LayerMask knightLayer;
    public int attackDamage =3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          Collider2D[] knight = Physics2D.OverlapCircleAll(weapon.transform.position, attackRange, knightLayer);
            if (knight.Length > 0){
             foreach (Collider2D item in knight)
             {
                   GobAnim.SetBool("attack", true);
                 
                
           
             }}
          
    }
    // what is the error here?
  public void END_Attack()
        {
            GobAnim.SetBool("attack", false);
        }

     
   

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(weapon.transform.position, attackRange);
    }
}
