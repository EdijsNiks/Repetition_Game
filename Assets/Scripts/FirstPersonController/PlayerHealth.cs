using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int currentHealth = 10;
    public int internalHealth;

    [SerializeField] private GameObject credits;
    private float timer = -1f; // Use -1 to indicate that the timer is not active

    void Update()
    {
        internalHealth = currentHealth;
        if (currentHealth <= 0 && timer == -1f) // Start timer only once
        {
            ResetHealth();
            credits.SetActive(true);
            timer = 5f; // Start the timer for credits display
        }

        // Decrement timer and deactivate credits after 5 seconds
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                credits.SetActive(false);
                SceneManager.LoadScene(2); // Assuming scene index 2 is your game over scene
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void ResetHealth()
    {
        currentHealth = 10;
    }
}