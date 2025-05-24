using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void GameplayScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
