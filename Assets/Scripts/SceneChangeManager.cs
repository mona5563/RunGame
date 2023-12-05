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
            //�Q�[���v���C�I��
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            //�Q�[���v���C�I��
            Application.Quit();
        #endif
    }

}
