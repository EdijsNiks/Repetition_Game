using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    [SerializeField] private KeyCode openKey; // Key to open the keypad
    [SerializeField] private KeyCode closeKey; // Key to close the keypad

    [SerializeField] private FirstPersonController player;
    [SerializeField] private GameObject keypadUI; // Reference to the keypad UI GameObject
    [SerializeField] private Text inputText; // Reference to the text displaying entered code
    
    [SerializeField] private string correctCode; // The actual code required to unlock something
        [SerializeField] private GameObject mainDoorTrigger; // Reference to the keypad UI GameObject


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
            mainDoorTrigger.SetActive(true);
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
            OnExit(); 
        }
    }
}