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

    //イベントの難易度マネージャー
    [SerializeField] EventLevelManager levelManager;
    //難易度用ノイズを決めるためのオクターブ数
    [SerializeField] private int levelOctaves;
    //イベントオブジェクト用ノイズを決めるためのオクターブ数
    [SerializeField] private int eventObjectOctaves;
    //難易度用ノイズの速度
    [SerializeField] private float levelNoiseSpeed;
    //イベントオブジェクト用ノイズの速度
    [SerializeField] private float eventObjectNoiseSpeed;

    //難易度用ノイズ
    private Noise levelNoise;
    //イベントオブジェクト用ノイズ
    private Noise eventObjectNoise;

    //難易度用ノイズ位置
    private float levelNoisePos;
    //イベントオブジェクト用ノイズ位置
    private float eventObjectNoisePos;

    // Start is called before the first frame update
    void Start()
    {
        //難易度とオブジェクトを変化させるためのパーリンノイズを作成
        levelNoise = new Noise();
        eventObjectNoise = new Noise();

        //シード値の設定
        int seed = (int)System.DateTime.Now.Ticks;
        Random.InitState(seed);

        //最初のステージの生成
        stageNum = firstStageNum - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの位置がステージのどこか割り出す
        int playerPosIndex = (int)(player.position.z / stageSize);

        //ステージを超えたか
        if(playerPosIndex + aheadStage > stageNum)
        {
            //新しくステージを生成する為にマネージャーを呼ぶ
            StageManager(playerPosIndex + aheadStage);
        }
    }

    /// <summary>
    /// ステージを管理する
    /// </summary>
    /// <param name="maps"></param>
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

    /// <summary>
    /// ステージを生成する
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    GameObject MakeStage(int index)
    {
        //次のステージをランダムで決める
        int nextStage = Random.Range(0, grounds.Length);

        //ステージを生成する
        GameObject stageObject = (GameObject)Instantiate(grounds[nextStage], new Vector3(0, 0, index * stageSize), Quaternion.identity);

        //イベントを生成する
        CreateEventPoints(stageObject);

        return stageObject;
    }

    /// <summary>
    /// ステージを削除する
    /// </summary>
    void DestroyStage()
    {
        GameObject oldStage = stageList[0];
        stageList.RemoveAt(0);
        Destroy(oldStage);
    }

    /// <summary>
    /// イベントポイントを作成する
    /// </summary>
    /// <param name="grandObject"></param>
    private void CreateEventPoints(GameObject grandObject)
    {
        GroundObject ground = grandObject.GetComponent<GroundObject>();
        int maxEventCount = ground.GetEventPointCount();

        //生成するイベント数の上限を10にする
        if (maxEventCount > 10)
        {
            maxEventCount = 10;
        }

        //  配置するイベントの数
        //乱数生成の偏りを少なくするため10掛ける
        int eventCount = Random.Range(50, maxEventCount * 10);
        eventCount /= 10;

        //イベントを設置する場所とイベントを作成
        List<bool> eventList = new List<bool>();
        int eventListMaxIndex = ground.GetEventPointCount();

        for (int i = 0; i < eventListMaxIndex; i++)
        {
            eventList.Add(false);
        }

        for (int i = 0; i < eventCount; i++)
        {
            // ランダムで位置決定
            int randomIndex = Random.Range(0, eventListMaxIndex);

            while (eventList[randomIndex])
            {
                //すでに場所が決まっていたら再度ランダムで決める
                randomIndex = Random.Range(0, eventListMaxIndex);
            }

            //置く場所が決まった
            eventList[randomIndex] = true;

            //イベントを作成するレベルの決定を行う
            float levelNoiseValue = levelNoise.Octave((uint)levelOctaves, levelNoisePos);
            float eventObjectNoiseValue = eventObjectNoise.Octave((uint)eventObjectOctaves, eventObjectNoisePos);

            levelNoiseValue += 0.5f;
            eventObjectNoiseValue += 0.5f;

            levelNoisePos += levelNoiseSpeed;
            if (levelNoisePos >= 256.0f)
            {
                levelNoisePos -= 256.0f;
            }

            eventObjectNoisePos += eventObjectNoiseSpeed;
            if (eventObjectNoisePos >= 256.0f)
            {
                eventObjectNoisePos -= 256.0f;
            }

            //  イベント発生オブジェクト
            GameObject getEventIndex = ground.GetEventPoint(randomIndex);

            //  難易度別オブジェクト
            GameObject newEvent = levelManager.GetPrefabObject(levelNoiseValue, eventObjectNoiseValue);

            newEvent.SetActive(true);
            newEvent.transform.SetParent(getEventIndex.transform);
            newEvent.transform.position = Vector3.zero;
            newEvent.transform.localPosition = Vector3.zero;
        }
    }
}
