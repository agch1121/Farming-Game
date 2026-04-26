using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string levelToStart;


    private void Start()
    {
        AudioManager.instance.PlayTitle();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(levelToStart);

        AudioManager.instance.playNextBGM();

        AudioManager.instance.PlaySFXPitchAdjusted(5);
    }

    public void QuitGame()
    {
        Application.Quit(); // 에디터 환경에서는 종료되지 않음

        Debug.Log("Quitting The Game");

        AudioManager.instance.PlaySFXPitchAdjusted(5);
    }
}
