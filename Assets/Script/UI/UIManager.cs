using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneTransition.SwitchToScene("Game Scene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
