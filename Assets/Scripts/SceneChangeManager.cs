using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    [SerializeField]
    private Fade fade = null;

    [SerializeField]
    private int targetScene = 0;

    public void ChangeScene(int sceneNumber)
    {
        targetScene = sceneNumber;
        SceneManager.LoadScene(targetScene);
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
