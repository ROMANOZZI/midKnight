using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isTakingDamage;

    private Coroutine damageCoroutine;

    void Start()
    {
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
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            // Player is defeated or dies
            Debug.Log("Player defeated");
            // Add additional code here for player death, like game over or resetting the level

            // Destroy the player object
            Destroy(gameObject);

            // Restart the level instantly
            RestartLevel();
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
            isTakingDamage = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
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

    private void RestartLevel()
    {
        // Restart the level or perform any other necessary actions
        // You can replace the code below with your desired restart logic

        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene again to restart
        SceneManager.LoadScene(currentSceneIndex);
    }
}
