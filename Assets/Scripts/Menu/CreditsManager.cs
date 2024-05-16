using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class CreditsManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsTextObject; // Reference to the credits text GameObject
    [SerializeField] private float fadeSpeed = 1f; 
    [SerializeField] private float creditsSpeed = 0.5f; // Speed at which credits text moves
    [SerializeField] private float skipDelay = 5f; 

    private bool isCreditsPlaying = false;
    private float elapsedTime = 0f;

    void Start()
    {
        creditsTextObject.SetActive(true); 
    }

    public void PlayCredits() 
    {
        isCreditsPlaying = true;
        elapsedTime = 0f;
    }

    void Update()
    {
        if (!isCreditsPlaying)
            return;

        elapsedTime += Time.deltaTime;

        creditsTextObject.transform.position += Vector3.up * creditsSpeed * Time.deltaTime;

        if (elapsedTime > skipDelay)
        {
            LoadGameOverScene(); 
        }
    }

    void LoadGameOverScene()
    {
        isCreditsPlaying = true; 
        SceneManager.LoadScene(2); 
        Destroy(creditsTextObject);
    }
}