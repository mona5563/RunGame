/*Pause
 *2023/12/06  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //�|�[�Y���Ă��邩����
    private bool isPause = false;
    //�|�[�Y���̉��
    [SerializeField] GameObject pausePanel;

    //�|�[�Y���ɔ�\���ɂ���I�u�W�F�N�g
    [SerializeField] GameObject deleteText;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        //�N�����|�[�Y��ʂ�\�����Ȃ�
        pausePanel.SetActive(false);
        //�e�L�X�g�͕\�������Ă���
        deleteText.SetActive(true);

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

    /// <summary>
    /// �|�[�Y��ʂ��J��
    /// </summary>
    public void OpenPause()
    {
        isPause = true;
        //�|�[�Y��ʂ�\������
        pausePanel.SetActive(true);
        //�e�L�X�g���\���ɂ���
        deleteText.SetActive(false);
        //���Ԃ��~������
        Time.timeScale = 0;   
    }

    /// <summary>
    /// �|�[�Y��ʂ����
    /// </summary>
    public void ClosePause()
    {
        isPause = false;
        //�|�[�Y��ʂ��\���ɂ���
        pausePanel.SetActive(false);
        //�e�L�X�g��\������
        deleteText.SetActive(true);
        //���Ԃ�i�߂�
        Time.timeScale = 1;
    }
}
