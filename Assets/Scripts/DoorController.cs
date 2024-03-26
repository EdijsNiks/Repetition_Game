using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
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
            doorOpen = true;
        }
        else
        {
            doorAnimator.Play("Door1Close", 0, 0.0f);
            doorOpen = false;
        }
    }
}
