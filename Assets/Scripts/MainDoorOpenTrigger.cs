using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorOpenTrigger : MonoBehaviour
{
    public GameObject door;                     // Reference to the door GameObject
    public AudioSource doorOpenSound;           // Reference to the door opening sound effect
    private bool doorOpened = false;            // Flag to track if door has already been opened

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !doorOpened)
        {
            // Open the door by rotating it 90 degrees on the Y-axis
            door.transform.Rotate(Vector3.up * -90f);

            // Play the door opening sound effect
            if (doorOpenSound != null)
            {
                doorOpenSound.Play();
            }
            else
            {
                Debug.LogWarning("MainDoorOpenTrigger: No door opening sound assigned!");
            }

            doorOpened = true;                // Mark door as opened

            
            Destroy(gameObject, 1.0f);      
        }
    }
}