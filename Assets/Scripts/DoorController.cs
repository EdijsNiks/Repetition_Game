using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
    private bool doorOpen = false;
    [SerializeField] TextMeshPro useText;
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
            useText.SetText("Door1Open");
        }
        else
        {
            doorAnimator.Play("Door1Close", 0, 0.0f);
            doorOpen = false;
        }
    }
}
