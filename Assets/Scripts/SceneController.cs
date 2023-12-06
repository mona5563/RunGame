using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private Fade sceneFader;

    private void Start()
    {
        sceneFader = FindObjectOfType<Fade>();
    }

    public void ChangeScene(int sceneNumber)
    {
        Debug.Log(sceneNumber);

        //時間が止まっていたら
        if(Time.timeScale == 0)
        {
            //時間を進める
            Time.timeScale = 1;
        }

        sceneFader.FadeToScene(sceneNumber);
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

