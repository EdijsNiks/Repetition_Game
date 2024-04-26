using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WriteTextEffect : MonoBehaviour
{
    [SerializeField] private GameObject textfieldGameObject; // Reference to the text field GameObject
    [SerializeField] private TMP_Text textfield; // Reference to the TMPro text field within the text field GameObject (optional)
    [SerializeField] private string textToWrite; // The text to be written out
    [SerializeField] private float delayPerLetter = 0.1f; // Delay between writing each letter (seconds)
    [SerializeField] private float delayAfterText = 3.0f; // Delay before disabling the text field

    private IEnumerator WriteTextCoroutine;

    void OnEnable() // Called when the script's GameObject becomes active
    {
            textfieldGameObject.SetActive(true);
            if (textfieldGameObject != null)
            {
                textfieldGameObject.SetActive(true); // Activate the text field GameObject on scene load

                if (textfield != null) // Check if textfield reference is set within the GameObject
                {
                    WriteTextCoroutine = WriteText(textToWrite);
                    StartCoroutine(WriteTextCoroutine);
                }
                else
                {
                    Debug.LogError("Missing textfield reference in WriteTextEffect script!");
                }
            }
            else
            {
                Debug.LogError("Missing textfieldGameObject reference in WriteTextEffect script!");
            }
        }

    IEnumerator WriteText(string text)
    {
        if (textfield == null) // Check again if textfield reference exists in case it's not set in Inspector
        {
            yield break; // Exit coroutine if textfield is missing
        }

        textfield.text = ""; // Clear the text field initially

        foreach (char letter in text)
        {
            textfield.text += letter;
            yield return new WaitForSeconds(delayPerLetter);
        }

        yield return new WaitForSeconds(delayAfterText); // Wait after text is written

        textfieldGameObject.SetActive(false); // Disable the text field GameObject
    }
}

