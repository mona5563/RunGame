/*EventLevelManager
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLevelManager : MonoBehaviour
{
    //難易度評価リスト
    [SerializeField]
    private List<float> levelRateList;

    //難易度リスト
    [SerializeField]
    private List<EventObjectManager> levelList;

    //評価合計
    private float levelRateSum;

    // Start is called before the first frame update
    void Start()
    {
        levelRateSum = 0.0f;

        foreach(float rate in levelRateList)
        {
            levelRateSum += rate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPrefabObject(float levelRate, float eventRate)
    {
        GameObject ret = null;
        float getRate = levelRate;

        //  レートが不正な値だったら補正する
        if (getRate < 0.0f)
        {
            getRate = 0.0f;
        }

        if (getRate > 1.0f)
        {
            getRate = 1.0f;
        }

        //  レートをルーレット判断できる形に変換
        getRate *= levelRateSum;

        int rankObjIndex = 0;
        EventObjectManager selectObjectManager = null;

        //  ルーレット式で当たったランクを判定
        foreach (float rate in levelRateList)
        {
            getRate -= rate;
            if (getRate <= 0.0f)
            {
                //  ルーレットの当たった場所が出たので、該当マネージャを確保してループを終える
                selectObjectManager = levelList[rankObjIndex];
                break;
            }
            rankObjIndex++;
        }

        //  おかしな値であれば、最後のオブジェクトにする
        if (selectObjectManager == null)
        {
            selectObjectManager = levelList[levelList.Count - 1];
        }

        //  取得した難易度から該当するprefabオブジェクトを獲得する
        GameObject originObject = selectObjectManager.GetPrefabObject(eventRate);
        ret = Instantiate(originObject);

        //  座標を完全に原点とする
        ret.transform.position = Vector3.zero;
        ret.transform.localPosition = Vector3.zero;

        return ret;
    }
}
