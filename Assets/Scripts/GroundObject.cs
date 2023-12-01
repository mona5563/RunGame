/*GroundObject
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObject : MonoBehaviour
{
    //イベント生成位置リスト
    [SerializeField] private List<GameObject> eventPointList;

    /// <summary>
    /// イベント位置を取得する
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject GetEventPoint(int index)
    {
        int getIndex = index;

        //Indexが不正だったら補正する
        if (getIndex < 0)
        {
            getIndex = 0;
        }
        if (getIndex >= eventPointList.Count)
        {
            getIndex = eventPointList.Count - 1;
        }

        return eventPointList[getIndex];
    }

    /// <summary>
    /// イベント位置の総数
    /// </summary>
    /// <returns></returns>
    public int GetEventPointCount()
    {
        return eventPointList.Count;
    }
}
