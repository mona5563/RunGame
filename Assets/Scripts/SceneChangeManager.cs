using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            //ゲームプレイ終了
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            //ゲームプレイ終了
            Application.Quit();
        #endif
    }

}
