using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] private GameObject pickupText;
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private GameObject enemyTrigger;
    [SerializeField] private string excludeLayerName = null;

    [SerializeField] private KeyCode pickupGun = KeyCode.E;
    private const string interactableTag = "InteractiveGun";

    [SerializeField] private GameObject playerGun;
    [SerializeField] private GameObject fakeGun;
    [SerializeField] private GunAttack gunAttack;  // Reference to the GunAttack script

    private void Start()
    {
        // Ensure the GunAttack script is initially disabled
        if (gunAttack != null)
        {
            gunAttack.enabled = false;
        }
        else
        {
            Debug.LogWarning("GunAttack script is not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        // Check for raycast hit
        bool isObjectInRaycast = Physics.Raycast(transform.position, fwd, out hit, rayLength, mask);

        // Update text visibility based on raycast
        pickupText.SetActive(isObjectInRaycast && hit.collider.CompareTag(interactableTag));

        // Handle gun pickup logic (assuming object is in raycast)
        if (isObjectInRaycast && hit.collider.CompareTag(interactableTag) && Input.GetKeyDown(pickupGun))
        {
            playerGun.SetActive(true);
            fakeGun.SetActive(false);
            enemyTrigger.SetActive(true);

            // Enable the GunAttack script when the gun is picked up
            if (gunAttack != null)
            {
                gunAttack.enabled = true;
            }
        }
    }
}
