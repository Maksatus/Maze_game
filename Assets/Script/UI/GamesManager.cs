using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsVictory = false;
    public GameObject pauseMenuUI;
    public GameObject victoryUI;
    public GameObject GameUI;
    public GameObject joystickUI;


    private void Start()
    {
        if (move_.MoveControls)
        {
            joystickUI.SetActive(false);
        }
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (GameIsVictory)
        {
            Victory();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Pause_menu()
    {
        GameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Victory()
    {
        GameUI.SetActive(false);
        victoryUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsVictory = false;
        GameIsPaused = true;
    }

    public void Return()
    {
        pauseMenuUI.SetActive(false);
        victoryUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameUI.SetActive(true);
        Timer.start = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        GameIsPaused = false;
        GameUI.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Pause()
    {
        Pause_menu();
    }

}
