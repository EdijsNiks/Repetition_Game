using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    [SerializeField] private KeyCode openKey; // Key to open the keypad
    [SerializeField] private KeyCode closeKey; // Key to open the keypad

    [SerializeField] private FirstPersonController player;
    [SerializeField] private GameObject keypadUI; // Reference to the keypad UI GameObject
    [SerializeField] private Text inputText; // Reference to the text displaying entered code
    
    [SerializeField] private string correctCode; // The actual code required to unlock something
  //  [SerializeField] private AudioSource buttonSound; // Sound effect for button press
  //  [SerializeField] private AudioSource correctSound; // Sound effect for correct code entry
  //  [SerializeField] private AudioSource wrongSound; // Sound effect for wrong code entry
  //  [SerializeField] private GameObject animateObject; // Object to animate on correct code entry (optional)
  //  [SerializeField] private Animator animator; // Animator component for the animateObject (optional)
    private bool isOpen = false;
    public string pressedEnter;

    public void OpenKeypad()
    {
        if (!isOpen) // Prevent accidental reopening
        {
            keypadUI.SetActive(true);
            inputText.text = ""; // Clear previous input
            DisablePlayer(true);
            isOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnNumberPress(int number)
    {
        inputText.text += number.ToString();
        //buttonSound.Play();
    }

    public void OnSubmit()
    {
        if (inputText.text == correctCode)
        {
           // correctSound.Play();
            inputText.text = "Correct!";
            pressedEnter = "Open";
        }
        else
        {
            //wrongSound.Play();
            inputText.text = "Wrong Code";
            
        }
    }
        void DisablePlayer(bool disable)
    {
        player.enabled = !disable;
    }
        public void Clear()
    {
        {
            inputText.text = "";
        }
    }
    public void OnExit()
    {
        keypadUI.SetActive(false);
        DisablePlayer(false);
        isOpen = false;
        Cursor.visible = false;

    }

    void Update()
    {
        if (isOpen && Input.GetKeyDown(closeKey))
        {
            OnExit(); // Close keypad with same key used to open
        }
    }
}