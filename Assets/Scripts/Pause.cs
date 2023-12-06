using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //�|�[�Y���Ă��邩����
    private bool isPause = false;
    //�|�[�Y���̉��
    [SerializeField] GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        pausePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Tab�L�[�������ꂽ��
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //�|�[�Y���Ȃ�
            if(isPause)
            {
                //�|�[�Y��ʂ����
                ClosePause();
            }
            else
            {
                //�|�[�Y��ʂ��J��
                OpenPause();
            }
        }
    }

    public void OpenPause()
    {
        isPause = true;
        //�|�[�Y��ʂ�\������
        pausePanel.SetActive(true);
        //���Ԃ��~������
        Time.timeScale = 0;    }

    public void ClosePause()
    {
        isPause = false;
        //�|�[�Y��ʂ��\���ɂ���
        pausePanel.SetActive(false);
        //���Ԃ�i�߂�
        Time.timeScale = 1;
    }
}
