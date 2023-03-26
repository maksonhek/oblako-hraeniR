using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseScreen : MonoBehaviour
{
   public void closeGame(){
    Application.Quit();
   }
   public void RetryLevel(){
    SceneManager.LoadScene(SceneID.gameSceneID);
   }
}
