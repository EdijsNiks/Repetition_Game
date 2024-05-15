using UnityEngine;
using System.Collections;


public class GunAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint; // Transform for the firing position (e.g., gun barrel)
    [SerializeField] private float attackRange = 100f; // Maximum range of the attack
    [SerializeField] private LayerMask attackableLayers; // Layers considered valid targets
    [SerializeField] private float fireRate = 1.0f; // Shots per second
    [SerializeField] private Animator animator; // Reference to the Animator component

    private float nextTimeToFire = 0f; // Time for next allowed shot
    private bool isShooting = false; // Flag to track if currently shooting

    public delegate void OnEnemyHit(EnemyHealth enemyHealth); // Delegate for notifying when an enemy is hit
    public OnEnemyHit onEnemyHit; // Event for notifying when an enemy is hit

    void Update()
    {
        if (Input.GetButton("Fire1") && !isShooting && Time.time >= nextTimeToFire) // Check for fire input, not shooting, and fire rate cooldown
        {
            nextTimeToFire = Time.time + 1f / fireRate; // Reset fire cooldown
            isShooting = true; // Mark as shooting

            FireGun();
        }
    }

    private void FireGun()
    {
        if (animator != null)
        {
            animator.SetTrigger("GunShoot"); // Trigger the GunShot animation
        }

        // Raycast after a short delay to simulate bullet travel time (optional)
        StartCoroutine(PerformRaycastAfterDelay(0.1f)); 
    }

    IEnumerator PerformRaycastAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, attackRange, attackableLayers))
        {
            // Enemy hit! Deal damage and notify listeners
            Debug.Log("Hit");
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20); // Replace "damage" with your actual damage value
                onEnemyHit?.Invoke(enemyHealth); // Invoke event with enemyHealth reference
            }
        }

        isShooting = false; // Allow shooting again after animation ends (assuming animation has an "End" event or similar)
    }
}
