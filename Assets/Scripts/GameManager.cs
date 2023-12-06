/*GameManager
 * 2023/11/15
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro���g����悤�ɂ���

public class GameManager : MonoBehaviour
{
    //�I�[�f�B�I�\�[�X
    [SerializeField] AudioSource audioSource;
    //�X�R�A
    public static int score = 0;
    //�X�R�A�e�L�X�g
    [SerializeField] TextMeshProUGUI scoreText;

    public static int GetScore()
    {
        return score;
    }

    // Start is called before the first frame update
    void Start()
    {
        //�N�����X�R�A�̏����l��0�ɂ���
        score = 0;
        //�A�C�e�����W����SE���擾
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            //ESC�L�[�������ꂽ��Q�[�����I������
            EndGame();
        }
    }

    public void UpdateScore()
    {
        //�A�C�e�����W����SE���Đ�����
        audioSource.Play();
        //�X�R�A�����Z����
        score++;
        //�X�R�A��\������
        scoreText.text = "Score:" + score;
    } 

    public void EndGame()
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
