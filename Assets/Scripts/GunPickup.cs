using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DoorController rayCastedObj;

    [SerializeField] private KeyCode pickupGun = KeyCode.E;
    private const string interactableTag = "InteractiveGun";

    [SerializeField] private GameObject playerGun;
    [SerializeField] private GameObject fakeGun;



    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            // Door opening //
            if (hit.collider.CompareTag(interactableTag))
            {
                if (Input.GetKeyDown(pickupGun))
                {
                    playerGun.SetActive(true);
                    fakeGun.SetActive(false);
                }
            }
        }
    }
}
