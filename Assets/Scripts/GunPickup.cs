using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] GameObject pickupText;
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private GameObject enemyTrigger;
    [SerializeField] private string excludeLayerName = null;

    private DoorController rayCastedObj;  // Not used in this revision, can be removed

    [SerializeField] private KeyCode pickupGun = KeyCode.E;
    private const string interactableTag = "InteractiveGun";

    [SerializeField] GameObject playerGun;
    [SerializeField] GameObject fakeGun;

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
        }
    }
}