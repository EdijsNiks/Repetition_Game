/*using System.Collections;
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
*/
using UnityEngine;
using UnityEngine.UI;

public class Dooropening : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DoorController rayCastedObj;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;
    [SerializeField] private GameObject interactionIndicator; // Reference to the UI element representing the "E" button
    [SerializeField] private Transform indicatorParent; // Parent transform for positioning the indicator

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

                // Show the interaction indicator
                interactionIndicator.SetActive(true);

                // Position the indicator near the interactable object
                Vector3 indicatorPosition = hit.collider.gameObject.transform.position;
                indicatorParent.position = indicatorPosition;

                if (Input.GetKeyDown(openDoorKey))
                {
                    if (rayCastedObj != null)
                    {
                        rayCastedObj.PlayAnimation();
                    }
                }
            }
            else
            {
                // Hide the interaction indicator if the player is not near the door
                interactionIndicator.SetActive(false);
            }
        }
        else
        {
            // Hide the interaction indicator if the player is not looking at an interactive object
            interactionIndicator.SetActive(false);
        }
    }
}
