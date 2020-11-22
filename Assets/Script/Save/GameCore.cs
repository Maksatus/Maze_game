using Structs;
using UnityEngine;
using System;
using System.IO;    


public class GameCore : MonoBehaviour
{
    private string savePath;
    private string saveFileName = "data.json";


    [Header("Leves")]
    [SerializeField] private int lastLevelIndex;


    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
    savePath = Path.Combine(Application.persistentDataPath,saveFileName)
#else
        savePath = Path.Combine(Application.dataPath,saveFileName);
#endif
       // LoadFromFille();
    }

    public void SaveToFille(LevelStruct levelImport)
    {
        GameCoreStruct gameCore = new GameCoreStruct
        {
            lastLevelIndex = this.lastLevelIndex,
            level = levelImport
        };
        
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
 /*   
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
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
 */
}

namespace Structs
{
    [System.Serializable]

    public struct GameCoreStruct
    {
         public int lastLevelIndex;
         public LevelStruct level;
    }
}