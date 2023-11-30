/*EventObjectManager
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObjectManager : MonoBehaviour
{
    //イベント発生率リスト
    [SerializeField]
    private List<float> eventRateList;

    //発生させるイベントリスト
    [SerializeField]
    private List<GameObject> eventList;

    private float eventRateSum;

    // Start is called before the first frame update
    void Start()
    {
        eventRateSum = 0.0f;

        foreach (float rate in eventRateList)
        {
            eventRateSum += rate;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPrefabObject(float eventRate)
    {
        GameObject ret = null;
        float getRate = eventRate;

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
        getRate *= eventRateSum;

        int eventObjIndex = 0;

        //  ルーレット式で当たったイベントを判定
        foreach (float rate in eventRateList)
        {
            getRate -= rate;
            if (getRate <= 0.0f)
            {
                //  ルーレットの当たった場所が出たので、該当イベントを確保してループを終える
                ret = eventList[eventObjIndex];
                break;
            }
            eventObjIndex++;
        }

        //  おかしな値であれば、最後のオブジェクトにする
        if (ret == null)
        {
            ret = eventList[eventList.Count - 1];
        }

        return ret;
    }
}
