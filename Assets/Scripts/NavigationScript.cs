using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    [SerializeField] private FirstPersonController player;
    [SerializeField] private  int damage;
    [SerializeField] private PlayerHealth playerHealth;  // Reference to PlayerHealth script
    [SerializeField] private float attackDelay = 1.0f;    // Time enemy pauses after attacking
    [SerializeField] private float attackRange = 1.0f;    // Distance within which the enemy attacks

    private NavMeshAgent agent;
    private bool isAttacking = false;  // Flag to track enemy attack state

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!isAttacking)  // Only update destination if not attacking
        {
            agent.destination = player.transform.position;
            CheckForPlayerAttack();
        }
    }

    private void CheckForPlayerAttack()
    {
        if (player != null)
        {
            // Raycast towards player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, attackRange))
            {
                // Check if raycast hit the player
                if (hit.collider.CompareTag("Player"))
                {
                    isAttacking = true;
                    StartCoroutine(AttackPlayer());
                }
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        if (playerHealth != null)  // Check if PlayerHealth script is assigned
        {
            playerHealth.TakeDamage(damage);  // Reduce player health by 5
        }

        yield return new WaitForSeconds(attackDelay);  // Pause for attack delay
        isAttacking = false;  // Allow enemy to move again
    }
}