using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooropening : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DoorController rayCastedObj;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                rayCastedObj = hit.collider.gameObject.GetComponent<DoorController>();

                if (Input.GetKeyDown(openDoorKey))
                {
                    if (rayCastedObj != null)
                    {
                        rayCastedObj.PlayAnimation();
                    }
                }
            }
        }
    }
}
