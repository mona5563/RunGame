/*GameManager
 * 2023/11/15
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProを使えるようにする

public class GameManager : MonoBehaviour
{
    //オーディオソース
    [SerializeField] AudioSource audioSource;
    //スコア
    public static int score = 0;
    //スコアテキスト
    [SerializeField] TextMeshProUGUI scoreText;

    public static int GetScore()
    {
        return score;
    }

    // Start is called before the first frame update
    void Start()
    {
        //アイテム収集時のSEを取得
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        //アイテム収集時にSEを再生する
        audioSource.Play();
        //スコアを加算する
        score++;
        //スコアを表示する
        scoreText.text = "Score:" + score;
    } 
}
