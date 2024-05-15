using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;  // Maximum health of the enemy

    private float currentHealth;  // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)  // Function to handle enemy taking damage
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)  // Check for death
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);  
    }
}
