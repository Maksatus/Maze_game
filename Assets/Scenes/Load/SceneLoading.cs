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
    public GameObject loadingScren;
    public Text tapText;

    public void Load()
    {
        loadingScren.SetActive(true);
        panel.SetActive(false);
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            float progress = asyncLoad.progress / 0.9f;
            LoadingImg.fillAmount = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            if (asyncLoad.progress>=0.9f && !asyncLoad.allowSceneActivation)
            {
                StartCoroutine(Text());
                if(Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
    IEnumerator Text()
    {
        yield return new WaitForSeconds(2);
        tapText.text = string.Format("Tap to screen!");
    }
}
