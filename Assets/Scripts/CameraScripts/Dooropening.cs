using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dooropening : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private Text interactionText;

    private DoorController rayCastedDoor;
    private KeypadController rayCastedKeypad;
    private NoteController rayCastedNote;

    private bool isLookingAtDoor = false;
    private bool isLookingAtKeypad = false;
    private bool isLookingAtNote = false;

    private const string doorTag = "InteractiveObject";
    private const string keypadTag = "InteractiveKey";
    private const string noteTag = "InteractiveNote";

    private void Start()
    {
        interactionText.enabled = false; // Disable interaction text at start
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(doorTag))
            {
                isLookingAtDoor = true;
                rayCastedDoor = hit.collider.gameObject.GetComponent<DoorController>();
            }
            else
            {
                isLookingAtDoor = false;
            }

            if (hit.collider.CompareTag(keypadTag))
            {
                isLookingAtKeypad = true;
                rayCastedKeypad = hit.collider.gameObject.GetComponent<KeypadController>();
            }
            else
            {
                isLookingAtKeypad = false;
            }

            if (hit.collider.CompareTag(noteTag))
            {
                isLookingAtNote = true;
                rayCastedNote = hit.collider.gameObject.GetComponent<NoteController>();
            }
            else
            {
                isLookingAtNote = false;
            }

            interactionText.enabled = true; // Enable interaction text when looking at an interactable object
            interactionText.text = "Press 'E' to interact";
        }
        else
        {
            isLookingAtDoor = false;
            isLookingAtKeypad = false;
            isLookingAtNote = false;
            interactionText.enabled = false; // Disable interaction text when not looking at an interactable object
        }

        // Handle interactions based on what the player is looking at and if they press the interaction key
        if (Input.GetKeyDown(interactionKey))
        {
            if (isLookingAtDoor && rayCastedDoor != null)
            {
                rayCastedDoor.PlayAnimation();
            }

            if (isLookingAtKeypad && rayCastedKeypad != null)
            {
                rayCastedKeypad.OpenKeypad();
            }

            if (isLookingAtNote && rayCastedNote != null)
            {
                rayCastedNote.ShowNote();
            }
        }
    }
}



