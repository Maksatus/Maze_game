using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, levelMenu,settingMenu;
    private void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero,0.25f);
    }
    public void level()
    {
        mainMenu.DOAnchorPos(new Vector2(-2070, 0), 0.25f);
        levelMenu.DOAnchorPos(new Vector2(0,0), 0.25f);
    }

    public void ControlsJoyskick()
    {
        move_.MoveControls = false;
    }
    public void ControlsAccelerometer()
    {
        move_.MoveControls = true;
    }

    public void closeLevel()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        levelMenu.DOAnchorPos(new Vector2(2070, 0), 0.25f);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
