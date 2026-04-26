using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string levelToStart;

    public void PlayGame()
    {
        SceneManager.LoadScene(levelToStart);
    }

    public void QuitGame()
    {
        Application.Quit(); // 에디터 환경에서는 종료되지 않음

        Debug.Log("Quitting The Game");
    }
}
