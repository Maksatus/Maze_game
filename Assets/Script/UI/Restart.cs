﻿using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
   public void Restartlevel()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
