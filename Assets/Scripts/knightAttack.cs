using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightAttack : MonoBehaviour
{
    public Animator playerAnim;
    public float attackDelay;
    public Transform weaponTransform;
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
           StartCoroutine(Attack());
        }}
        IEnumerator Attack()
        {
            playerAnim.Play("attackanim");
            Collider2D enemies = Physics2D.OverlapCircle(weaponTransform.position, attackRange, enemyLayer);
          yield return new WaitForSeconds(attackDelay);
           enemies.GetComponent<enemyHealth>().TakeDamage(attackDamage);
        }
            
           
    
    }

