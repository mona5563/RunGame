/*GenerateGrounds
 * 2023/11/21
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrounds : MonoBehaviour
{
    //Groundオブジェクト格納用配列
    [SerializeField] GameObject[] ground;
    //Groundオブジェクトを生成するZ軸の位置(最初に生成する位置はz80とする)
    [SerializeField] int zPos = 80;
    //常に生成しないよう制限するフラグ
    [SerializeField] bool creatingGround = false;
    //生成するGroundオブジェクトの番号
    [SerializeField] int groundNum;
    //生成するGroundオブジェクトのZ位置の変化量
    private int addZPos = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!creatingGround)
        {
            //生成中なら
            creatingGround = true;
            //コルーチンを呼び出す
            StartCoroutine(GenerateGround());
        }
    }

    /// <summary>
    /// コルーチンを使用してGroundオブジェクトをランダムに生成する
    /// </summary>
    /// <returns></returns>
    IEnumerator GenerateGround()
    {
        //生成するGroundオブジェクトをランダムで決める
        groundNum = Random.Range(0, 4);
        //オブジェクトを生成する
        Instantiate(ground[groundNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += addZPos;
        //コルーチンを5秒間停止させる
        yield return new WaitForSeconds(5);
        //生成が完了したことを知らせる
        creatingGround = false;
    }
}
