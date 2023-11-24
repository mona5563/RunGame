/*GenerateGrounds
 * 2023/11/21
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrounds : MonoBehaviour
{
    //ステージサイズ
    int stageSize = 20;
    //生成するステージの番号
    int stageNum;

    //プレイヤーのTransform
    [SerializeField] Transform player;
    //Groundオブジェクト格納用配列
    [SerializeField] GameObject[] grounds;
    //スタート時のステージ番号
    [SerializeField] int firstStageNum;
    //事前に生成するステージ
    [SerializeField] int aheadStage;
    //生成したステージのリスト
    [SerializeField] List<GameObject> stageList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int seed = (int)System.DateTime.Now.Ticks;
        Random.InitState(seed);

        stageNum = firstStageNum - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        int playerPosIndex = (int)(player.position.z / stageSize);

        if(playerPosIndex + aheadStage > stageNum)
        {
            StageManager(playerPosIndex + aheadStage);
        }
    }

    void StageManager(int maps)
    {
        if(maps <= stageNum)
        {
            return;
        }
        
        //指定したステージまで作成する
        for(int i = stageNum + 1; i <= maps; i++)
        {
            GameObject stage = MakeStage(i);
            stageList.Add(stage);
        }

        //古いステージを削除する
        while(stageList.Count > aheadStage + 1)
        {
            DestroyStage();
        }

        stageNum = maps;
    }

    GameObject MakeStage(int index)
    {
        //次のステージをランダムで決める
        int nextStage = Random.Range(0, grounds.Length);

        //ステージを生成する
        GameObject stageObject = (GameObject)Instantiate(grounds[nextStage], new Vector3(0, 0, index * stageSize), Quaternion.identity);

        return stageObject;
    }

    void DestroyStage()
    {
        GameObject oldStage = stageList[0];
        stageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
