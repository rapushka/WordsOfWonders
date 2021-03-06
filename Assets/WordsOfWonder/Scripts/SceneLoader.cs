using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void LoadLevelsListScene()
    {
        SceneManager.LoadScene("LevelsList");
    }

    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(GameOverParams.CompletedLevel + 1);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
