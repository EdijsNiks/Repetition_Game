using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GunAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint; // Transform for the firing position (e.g., gun barrel)
    [SerializeField] private float attackRange = 100f; // Maximum range of the attack
    [SerializeField] private LayerMask attackableLayers; // Layers considered valid targets
    [SerializeField] private float fireRate = 1.0f; // Shots per second
    [SerializeField] private AudioClip gunShotSound; // Gunshot sound
    [SerializeField] private int maxShots = 5; // Maximum number of shots
    [SerializeField] private Vector3 recoilRotation = new Vector3(-10f, 0f, 0f); // Recoil rotation (only on X-axis)
    [SerializeField] private float recoilDuration = 0.1f; // Duration of recoil effect
    [SerializeField] private Text infoText; // Reference to the UI Text element
    [SerializeField] private string outOfAmmoMessage = "Out of ammo!"; // Message to display when out of ammo
    [SerializeField] private string enemyKilledMessage = "Enemy killed!"; // Message to display when an enemy is killed

    private AudioSource audioSource; // Audio source component
    private float nextTimeToFire = 0f; // Time for next allowed shot
    private bool isShooting = false; // Flag to track if currently shooting
    private int shotsFired = 0; // Counter for shots fired
    private Quaternion originalRotation; // Original rotation of the gun

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there's no AudioSource component, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        originalRotation = transform.localRotation; // Store the original rotation of the gun
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && !isShooting && Time.time >= nextTimeToFire && shotsFired < maxShots) // Check for fire input, not shooting, fire rate cooldown, and shot limit
        {
            nextTimeToFire = Time.time + 1f / fireRate; // Reset fire cooldown
            isShooting = true; // Mark as shooting
            shotsFired++; // Increment shot counter

            FireGun();
        }
    }

    private void FireGun()
    {
        // Play gunshot sound
        if (gunShotSound != null)
        {
            audioSource.PlayOneShot(gunShotSound);
        }

        // Start the recoil effect coroutine
        StartCoroutine(HandleRecoil());

        // Raycast after a short delay to simulate bullet travel time (optional)
        StartCoroutine(PerformRaycastAfterDelay(0.1f));

        // Check if the player is out of ammo
        if (shotsFired >= maxShots)
        {
            ShowInfoText(outOfAmmoMessage);
        }
    }

    private IEnumerator HandleRecoil()
    {
        Quaternion targetRotation = originalRotation * Quaternion.Euler(recoilRotation);
        float elapsedTime = 0f;

        // Apply recoil rotation
        while (elapsedTime < recoilDuration)
        {
            transform.localRotation = Quaternion.Slerp(originalRotation, targetRotation, elapsedTime / recoilDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset rotation back to original
        elapsedTime = 0f;
        while (elapsedTime < recoilDuration)
        {
            transform.localRotation = Quaternion.Slerp(targetRotation, originalRotation, elapsedTime / recoilDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = originalRotation; // Ensure the rotation is exactly the original
        isShooting = false; // Allow shooting again
    }

    IEnumerator PerformRaycastAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Draw a debug line to visualize the raycast
        Debug.DrawLine(firePoint.position, firePoint.position + firePoint.forward * attackRange, Color.red, 0.1f);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, attackRange, attackableLayers))
        {
            // Enemy hit! Deal damage and notify listeners
            Debug.Log("Hit: " + hit.collider.name); // Output the name of the hit object for debugging
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20); // Replace "20" with your actual damage value
                ShowInfoText(enemyKilledMessage); // Show message when an enemy is killed
            }
        }
    }

    private void ShowInfoText(string message)
    {
        if (infoText != null)
        {
            infoText.text = message;
            infoText.gameObject.SetActive(true);
            StartCoroutine(HideInfoTextAfterDelay());
        }
    }

    private IEnumerator HideInfoTextAfterDelay()
    {
        yield return new WaitForSeconds(5f); // Hide after 5 seconds
        if (infoText != null)
        {
            infoText.gameObject.SetActive(false);
        }
    }
}
