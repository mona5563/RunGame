using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro���g����悤�ɂ���

public class ScoreText : MonoBehaviour
{
    //�X�R�A�e�L�X�g
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameManager.GetScore();
        //�X�R�A�̃e�L�X�g�\��
        scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
