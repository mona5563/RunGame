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
        //起動時スコアの初期値を0にする
        score = 0;
        //アイテム収集時のSEを取得
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            //ESCキーが押されたらゲームを終了する
            EndGame();
        }
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

    public void EndGame()
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
