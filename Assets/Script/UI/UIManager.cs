using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, levelMenu, shopMenu;

    private int levelUnLock;
    [SerializeField] private Button[] buttons;

    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);

        levelUnLock = PlayerPrefs.GetInt("levels", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelUnLock; i++)
        {
            buttons[i].interactable = true;
        }
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
    public void Shop()
    {
        mainMenu.DOAnchorPos(new Vector2(-2070, 0), 0.25f);
        shopMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void closeShop()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        shopMenu.DOAnchorPos(new Vector2(2070, 0), 0.25f);
    }

    public void ControlsJoyskick()
    {
        move_.MoveControls = false;
    }
    
    public void ControlsAccelerometer()
    {
        move_.MoveControls = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
