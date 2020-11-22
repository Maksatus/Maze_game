using UnityEngine;
using Structs;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeStart = 0;
    [SerializeField] private Text timeText;
    [SerializeField] private Text timeVictory;
    private LevelStruct level;

    public static bool start = false;

    void Start()
    {
        timeText.text = timeStart.ToString("F2").Replace(",", ":");

    }

    void Update()
    {
        if (start)
        {
            timeStart += Time.deltaTime;
            timeText.text = timeStart.ToString("F2").Replace(",",":");
        }
        else if (GamesManager.GameIsVictory)
        {
            timeVictory.text ="Time: " + timeStart.ToString("F2").Replace(",", ":");
            var save = gameObject.AddComponent<GameCore>();
            level.idLevel = SceneManager.GetActiveScene().buildIndex;
            level.time = timeStart;
            save.SaveToFille(level);
        }
    }
}
