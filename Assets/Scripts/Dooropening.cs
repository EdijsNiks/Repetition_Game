using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooropening : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DoorController rayCastedObj;
    private NoteController _noteController;
    private KeypadController _keypadController;
    [SerializeField] private KeyCode openDoorKey = KeyCode.E;
    private GameObject door1; // Reference to the GameObject of door1


    private const string interactableTag = "InteractiveObject";
    private const string interactableNote = "InteractiveNote";
    private const string interactableKey = "InteractiveKey";
    private const string interactableDoorLocked = "doorLocked";
    [SerializeField] private GameObject doorTag;


    private void Start(){
        door1 = GameObject.FindGameObjectWithTag("doorLocked");
        if (door1 != null){
                    Debug.Log("This message will be printed to the Unity console when the game starts.");

        }
    }

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
                rayCastedObj = hit.collider.gameObject.GetComponent<DoorController>();

                if (Input.GetKeyDown(openDoorKey))
                {
                    if (rayCastedObj != null)
                    {
                        rayCastedObj.PlayAnimation();
                    }
                }
            }
            // Note pickup //
            if (hit.collider.CompareTag(interactableNote))
            {
                var readableItem = hit.collider.gameObject.GetComponent<NoteController>();
                if (readableItem != null)
                {
                    _noteController = readableItem;
                }
                else
                {
                    ClearNote();
                }
            }
            else
            {
                ClearNote();
            }
            if (_noteController != null)
            {
                if (Input.GetKeyDown(openDoorKey))
                {
                    _noteController.ShowNote();
                }
            }
            // Keypad unlocking //!SECTION
            if (hit.collider.CompareTag(interactableKey))
            {
                _keypadController = hit.collider.gameObject.GetComponent<KeypadController>();

                if (Input.GetKeyDown(openDoorKey))
                {
                    if (_keypadController != null)
                    {
                        _keypadController.OpenKeypad();

                        if (_keypadController.pressedEnter == "Correct!")
                        {
                            door1.tag = interactableTag;
                            Debug.Log("Tag of " + door1.tag + " changed to " + interactableTag);
                        }
                    }
                }
            }
        }

        void ClearNote()
        {
            if (_noteController != null)
            {
                _noteController = null;
            }
        }

    }
}

