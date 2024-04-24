using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLoadScene2 : MonoBehaviour
{

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Optional: Subscribe to scene load event for future scenes
        // SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Optional: Unsubscribe from scene load event
        // SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
