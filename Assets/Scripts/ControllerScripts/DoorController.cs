using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
    public AudioSource doorOpenSound;           // Reference to the door opening sound effect
    public AudioSource doorCloseSound;          // Reference to the door closing sound effect
    private bool doorOpen = false;

    private void Awake()
    {
        doorAnimator = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnimator.Play("Door1Open", 0, 0.0f);
            if (doorOpenSound != null)
            {
                doorOpenSound.Play();
            }
            else
            {
                Debug.LogWarning("DoorController: No door opening sound assigned!");
            }
            doorOpen = true;
        }
        else
        {
            doorAnimator.Play("Door1Close", 0, 0.0f);
            if (doorCloseSound != null)
            {
                doorCloseSound.Play();
            }
            else
            {
                Debug.LogWarning("DoorController: No door closing sound assigned!");
            }
            doorOpen = false;
        }
    }
}


