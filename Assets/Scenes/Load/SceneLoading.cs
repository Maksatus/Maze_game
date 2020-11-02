using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [Header("Загружаемая сцена:")]
    public int sceneID;
    [Space]
    public Image LoadingImg;
    public Text progressText;
    public GameObject panel;

    void Start()
    {
        StartCoroutine(AsyncLoad());
        panel.SetActive(false);

    }
    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            LoadingImg.fillAmount = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
