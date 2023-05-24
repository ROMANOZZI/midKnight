using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isTakingDamage;
    public AudioSource damageSound;
    public Animator animator;
  

    private Coroutine damageCoroutine;

    void Start()
    {
        animator.SetBool("isDead", false);
        currentHealth = maxHealth;
        isTakingDamage = false;
    }

    void Update()
    {
        if (isTakingDamage && damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(TakeDamageRepeatedly(10)); // Adjust the damage amount as needed
        }
        else if (!isTakingDamage && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    public void TakeDamage(int damageAmount)

    {
        if (currentHealth== maxHealth)
        {
            damageSound.Play();
        }
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            // Player is defeated or dies
            
            // Add additional code here for player death, like game over or resetting the level

            // Destroy the player object
            animator.SetBool("isDead", true);
            
        }

     
        
      
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("isTakingDamage", true);
            isTakingDamage = true;
        }
         if (collision.gameObject.CompareTag("knives"))
        {
            Debug.Log("knife hit");
            animator.SetBool("isDead", true);
            
            

        }
    }
       // check if collison is with knife and then die
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("isTakingDamage", false);
            isTakingDamage = false;
        }
    }

    private IEnumerator TakeDamageRepeatedly(int damageAmount)
    {
        while (true)
        {
            TakeDamage(damageAmount);
            yield return new WaitForSeconds(0.3f); // Adjust the delay between damage intervals as needed
        }
    }

    public void RestartLevel()
    {
        // Restart the level or perform any other necessary actions
        // You can replace the code below with your desired restart logic

        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene again to restart
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void Die()
    {
        Destroy(gameObject);
        RestartLevel();
    }
}
