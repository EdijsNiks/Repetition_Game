using UnityEngine;

public class GunAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint;  // Transform for the firing position (e.g., gun barrel)
    [SerializeField] private float attackRange = 100f;  // Maximum range of the attack
    [SerializeField] private LayerMask attackableLayers;  // Layers considered valid targets
    [SerializeField] private float fireRate = 1.0f;  // Shots per second
    private float nextTimeToFire = 0f;  // Time for next allowed shot

    public delegate void OnEnemyHit(EnemyHealth enemyHealth); // Delegate for notifying when an enemy is hit
    public OnEnemyHit onEnemyHit;  // Event for notifying when an enemy is hit

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)  // Check for fire input and fire rate cooldown
        {
            nextTimeToFire = Time.time + 1f / fireRate;  // Reset fire cooldown

            FireGun();
        }
    }

    private void FireGun()
    {

    /*    if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }
*/
        // Raycast to check for enemies
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, attackRange, attackableLayers))
        {
            // Enemy hit! Deal damage and notify listeners
            Debug.Log("Hit");
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20);  // Replace "damage" with your actual damage value
               // onEnemyHit?.Invoke(enemyHealth);  // Invoke event with enemyHealth reference
            }
        }
    }
}
