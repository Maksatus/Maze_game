using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
 
public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, levelMenu;
    private void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero,0.25f);
    }
    public void level()
    {
        mainMenu.DOAnchorPos(new Vector2(-2070, 0), 0.25f);
        levelMenu.DOAnchorPos(new Vector2(0,0), 0.25f);
    }
    public void closeLevel()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        levelMenu.DOAnchorPos(new Vector2(2070, 0), 0.25f);
    }

    public void NewGame()
    {
       SceneManager.LoadScene("Game Scene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
