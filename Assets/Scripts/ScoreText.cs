using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProを使えるようにする

public class ScoreText : MonoBehaviour
{
    //スコアテキスト
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameManager.GetScore();
        //スコアのテキスト表示
        scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
