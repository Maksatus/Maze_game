using Structs;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    private string savePath;
    private string saveFileName = "data.json";

    [SerializeField] private int lastLevelIndex = 2;
    private LevelStruct[] levelStruct;

    [Header("Text timer")]
    [SerializeField] private Text[] textTimer;


    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        savePath = Path.Combine(Application.persistentDataPath,saveFileName);
#else
        savePath = Path.Combine(Application.dataPath,saveFileName);
#endif
        LoadFromFille();
    }

    public void SaveToFille(LevelStruct levelImport)
    {
        GameCoreStruct gameCore = new GameCoreStruct
        {
            lastLevelIndex = this.lastLevelIndex,
            level = new LevelStruct[lastLevelIndex]
        };
        Debug.Log($"Всего: {lastLevelIndex}, импортируем: {levelImport.idLevel-1}, Время: {levelImport.time}");

        if (levelStruct!=null)
        {
            gameCore.level = levelStruct;
            if (levelStruct[levelImport.idLevel - 1].time > levelImport.time || levelStruct[levelImport.idLevel - 1].time == 0)
            {
                gameCore.level[levelImport.idLevel - 1] = levelImport;
            }
        }
        else
        {
            gameCore.level[levelImport.idLevel - 1] = levelImport;
        }
        
        string json = JsonUtility.ToJson(gameCore, true);

        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (Exception e)
        {
            Debug.Log($"Error {e}");
        }
    }
  
    public void LoadFromFille()
    { 
        if (!File.Exists(savePath))
        {
            Debug.Log("{GameLog}=>{GameCore} - LoadFromFile ->File Not Found");
            return;
        }
        try
        {
            string json = File.ReadAllText(savePath);
            GameCoreStruct gameCoreStruct = JsonUtility.FromJson<GameCoreStruct>(json);
            this.lastLevelIndex = gameCoreStruct.lastLevelIndex;
            this.levelStruct = gameCoreStruct.level;
            for (int i = 0; i < textTimer.Length; i++)
            {
                if (levelStruct[i].time>0)
                {
                    textTimer[i].text = "Best time: " + levelStruct[i].time.ToString("F2").Replace(",", ":");
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

}

namespace Structs
{
    [System.Serializable]

    public struct GameCoreStruct
    {
         public int lastLevelIndex;
         public LevelStruct[] level;
    }
}