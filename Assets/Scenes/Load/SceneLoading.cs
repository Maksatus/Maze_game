using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
   // [Header("Загружаемая сцена:")]
    private int sceneID;
    [Space]
    public Image LoadingImg;
    public Text progressText;
    [Header("Что нужно скрыть:")]
    public GameObject[] panel;
    public GameObject loadingScren;
    public Text tapText;

    public void Load(int id)
    {
        sceneID = id;
        loadingScren.SetActive(true);
        for (int i = 0; i < panel.Length; i++)
        {
            panel[i].SetActive(false);
        }
       
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (!asyncLoad.allowSceneActivation)
            {
                float progress = asyncLoad.progress / 0.9f;
                LoadingImg.fillAmount = progress;
                progressText.text = string.Format("{0:0}%", progress * 100);
                tapText.text = string.Format("Tap to screen!");
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
