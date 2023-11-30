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
            //�Q�[���v���C�I��
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            //�Q�[���v���C�I��
            Application.Quit();
        #endif
    }

}
