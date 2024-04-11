using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public static bool Paused = false;
  public GameObject PauseMenuCanvas;
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (Paused)
      {
        Play();
      }
      else
      {
        Pause();
      }
    }
  }

  public void MainMenuButton()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  }

  public void Play()
  {
    PauseMenuCanvas.SetActive(false);
    Time.timeScale = 1f;
    Paused = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void Pause()
  {
    PauseMenuCanvas.SetActive(true);
    Time.timeScale = 0f;
    Paused = true;
    Cursor.lockState = CursorLockMode.None;
  }
}