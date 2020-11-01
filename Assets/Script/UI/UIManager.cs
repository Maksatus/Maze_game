using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public void NewGame()
    {
       SceneManager.LoadScene("Game Scene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
