using UnityEngine;
using UnityEngine.UI; // Import UI namespace for text handling
using UnityEngine.SceneManagement; 

public class EnterCar : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    private const string interactableTag = "Car";

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pickupText;  // Reference to existing pickup text
    [SerializeField] private GameObject enemy;        // Reference to the enemy GameObject
    [SerializeField] private GameObject credits;

    // Create a new GameObject for the teleportation text (avoid modifying existing pickupText)
    [SerializeField] private GameObject teleportText;

    private float timer = 0f;

    private void Start()
    {
        // Ensure teleportText is initially inactive
        teleportText.SetActive(false);
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        bool isObjectInRaycast = Physics.Raycast(transform.position, fwd, out hit, rayLength, mask);

        // Update pickup text visibility based on raycast
        pickupText.SetActive(isObjectInRaycast && hit.collider.CompareTag(interactableTag));

        if (isObjectInRaycast && hit.collider.CompareTag(interactableTag) && Input.GetKeyDown(openDoorKey))
        {
            if (!enemy.activeInHierarchy)
            {
                credits.SetActive(true);
                timer = 5f; // Start the timer for credits display
            }
            else
            {
                // Teleport player and display temporary message
                player.transform.position = new Vector3(394.9f, 0f, 144f);
                teleportText.SetActive(true); // Set text content
                timer = 3f; // Start timer for teleport text
            }
        }

        // Decrement timers and deactivate UI elements
        if (credits.activeInHierarchy && timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                credits.SetActive(false);
                SceneManager.LoadScene(2); 
            }
        }

        if (teleportText.activeInHierarchy && timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                teleportText.SetActive(false);
            }
        }
    }
}

