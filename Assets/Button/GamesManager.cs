using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject JoystickActiv;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        JoystickActiv.SetActive(true);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneTransition.SwitchToScene("Start");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Pause_menu()
    {
        JoystickActiv.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Return()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        JoystickActiv.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        Pause_menu();
    }

}
