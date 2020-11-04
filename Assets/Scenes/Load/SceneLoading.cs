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
    public GameObject panel;
    public GameObject loadingScren;
    public Text tapText;

    public void Load(int id)
    {
        sceneID = id;
        loadingScren.SetActive(true);
        panel.SetActive(false);
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);
        asyncLoad.allowSceneActivation = false;
        StartCoroutine(LoadFake());

        while (!asyncLoad.isDone)
        {
            if (!asyncLoad.allowSceneActivation)
            {            
                if(Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

    IEnumerator LoadFake()
    {
        for (float i = 0; i <= 1; i=i+0.1f)
        {
            yield return new WaitForSeconds(0.3f);
            LoadingImg.fillAmount = i/0.9f;
            progressText.text = string.Format("{0:0}%", (i * 100) / 0.9f);
        }
        yield return new WaitForSeconds(1);
        tapText.text = string.Format("Tap to screen!");
    }
}
