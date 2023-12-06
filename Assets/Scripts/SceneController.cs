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

        //���Ԃ��~�܂��Ă�����
        if(Time.timeScale == 0)
        {
            //���Ԃ�i�߂�
            Time.timeScale = 1;
        }

        sceneFader.FadeToScene(sceneNumber);
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

