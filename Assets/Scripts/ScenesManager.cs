using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        LogIn,
        MainMenu,
        Game,
        GameOverMenu,
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Game.ToString());
    }

    public void LoadNextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(Scene.GameOverMenu.ToString());
    }

    public void LoadLogin()
    {
        SceneManager.LoadScene(Scene.LogIn.ToString());
    }
}
