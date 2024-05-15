using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int currentHealth = 10;
    public int internalHealth;

    [SerializeField] private GameObject credits;
    private float timer = 0f; // Added timer variable

    void Update()
    {
        internalHealth = currentHealth;
        if (currentHealth <= 0)
        {
            ResetHealth();
            credits.SetActive(true);
            timer = 5f; // Start the timer for credits display
        }

        // Decrement timer and deactivate credits after 5 seconds
        if (credits.activeInHierarchy && timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                credits.SetActive(false);
                // Load the game over scene here
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