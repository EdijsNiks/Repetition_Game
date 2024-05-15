using UnityEngine;
using UnityEngine.SceneManagement; // Added for scene loading
using UnityEngine.UI; // Added for UI elements

public class CreditsManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsTextObject; // Reference to the credits text GameObject
    [SerializeField] private float fadeSpeed = 1f; // Speed at which credits text fades in
    [SerializeField] private float creditsSpeed = 0.5f; // Speed at which credits text moves
    [SerializeField] private float skipDelay = 5f; // Time before allowing credits skip
    //[SerializeField] private Text skipHintText; // Reference to the skip hint UI text

    private bool isCreditsPlaying = false;
    private float elapsedTime = 0f;
   // private CanvasGroup creditsCanvasGroup; // Added for fading

    void Start()
    {
        creditsTextObject.SetActive(true); // Initially show credits text (but not fully visible)
       // creditsCanvasGroup = creditsTextObject.GetComponent<CanvasGroup>(); // Get CanvasGroup component
       // creditsCanvasGroup.alpha = 0f; // Initially set alpha to 0 (fully transparent)
       // skipHintText.gameObject.SetActive(false); // Initially hide skip hint
    }

    public void PlayCredits() // No longer requires win/lose parameter
    {
        isCreditsPlaying = true;
        elapsedTime = 0f;
    }

    void Update()
    {
        if (!isCreditsPlaying)
            return;

        elapsedTime += Time.deltaTime;

        // Fade in credits text
       // creditsCanvasGroup.alpha = Mathf.Lerp(creditsCanvasGroup.alpha, 1f, fadeSpeed * Time.deltaTime);

        // Move credits text upwards
        creditsTextObject.transform.position += Vector3.up * creditsSpeed * Time.deltaTime;

        // Allow skipping after delay and automatic load after another 5 seconds
        if (elapsedTime > skipDelay)
        {
                LoadGameOverScene(); // Load Game Over scene automatically
        }
    }

    void SkipCredits()
    {
        isCreditsPlaying = false;
        //skipHintText.gameObject.SetActive(false); // Hide skip hint
        SceneManager.LoadScene("GameOverScene"); // Replace with your desired scene name
    }

    void LoadGameOverScene()
    {
        isCreditsPlaying = true; // Ensure credits are stopped
        SceneManager.LoadScene("GameOverScene"); // Replace with your desired scene name
        Destroy(creditsTextObject); // Destroy the credits text object after loading the scene
    }
}
