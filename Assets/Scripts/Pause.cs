using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //ポーズしているか判定
    private bool isPause = false;
    //ポーズ中の画面
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

    public void OpenPause()
    {
        isPause = true;
        //ポーズ画面を表示する
        pausePanel.SetActive(true);
        //時間を停止させる
        Time.timeScale = 0;    }

    public void ClosePause()
    {
        isPause = false;
        //ポーズ画面を非表示にする
        pausePanel.SetActive(false);
        //時間を進める
        Time.timeScale = 1;
    }
}
