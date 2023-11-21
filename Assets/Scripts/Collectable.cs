/*Collectable
 * 2023/11/10
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //アイテムの回転速度
    [SerializeField] float rotateSpeed = 0.5f;
    //ゲームマネージャー
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム起動時にGameManagerを設定する
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Y軸回転を行う
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    /// <summary>
    /// 衝突判定処理
    /// </summary>
    /// <param name="other">当たったオブジェクト</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //playerに当たったらスコアの計算とSEの再生を行う
            gameManager.UpdateScore();
            //オブジェクトを破壊する
            Destroy(gameObject);

        }
    }
}
