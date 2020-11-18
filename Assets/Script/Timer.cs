using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 0;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text timeVictory;

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
        else
        {
            timeVictory.text ="Time: " + timeStart.ToString("F2").Replace(",", ":");
        }
    }
}
