using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLoadScene2 : MonoBehaviour
{

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
