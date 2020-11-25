using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    private int sceneID;
    [Space]
    public Image LoadingImg;
    public Text progressText;
    public GameObject loadingScren;
    public Text tapText;

    public void Load(int id)
    {
        sceneID = id;
        loadingScren.SetActive(true);
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
                LoadingImg.fillAmount = Mathf.Lerp(LoadingImg.fillAmount, progress,
                Time.deltaTime * 5);
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
