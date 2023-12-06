/*Pause
 *2023/12/06  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //ポーズしているか判定
    private bool isPause = false;
    //ポーズ中の画面
    [SerializeField] GameObject pausePanel;

    //ポーズ中に非表示にするオブジェクト
    [SerializeField] GameObject deleteText;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        //起動時ポーズ画面を表示しない
        pausePanel.SetActive(false);
        //テキストは表示させておく
        deleteText.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //Tabキーを押されたら
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //ポーズ中なら
            if(isPause)
            {
                //ポーズ画面を閉じる
                ClosePause();
            }
            else
            {
                //ポーズ画面を開く
                OpenPause();
            }
        }
    }

    /// <summary>
    /// ポーズ画面を開く
    /// </summary>
    public void OpenPause()
    {
        isPause = true;
        //ポーズ画面を表示する
        pausePanel.SetActive(true);
        //テキストを非表示にする
        deleteText.SetActive(false);
        //時間を停止させる
        Time.timeScale = 0;   
    }

    /// <summary>
    /// ポーズ画面を閉じる
    /// </summary>
    public void ClosePause()
    {
        isPause = false;
        //ポーズ画面を非表示にする
        pausePanel.SetActive(false);
        //テキストを表示する
        deleteText.SetActive(true);
        //時間を進める
        Time.timeScale = 1;
    }
}
