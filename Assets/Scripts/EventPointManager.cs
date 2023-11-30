/*EventPointManager
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPointManager : MonoBehaviour
{
    //イベント出現位置リスト
    [SerializeField] List<GameObject> eventPointList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 総イベントポイント数を取得する
    /// </summary>
    /// <returns></returns>
    public int GetEventPointSize()
    {
        return eventPointList.Count;
    }

    /// <summary>
    /// イベントを出現させるポイントを取得する
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject GetEventPoint(int index)
    {
        if(index < 0 || index >= eventPointList.Count)
        {
            //指定されたインデックスが不正な値だった
            return null;
        }

        //指定されたインデックスのGameObjectを返す
        return eventPointList[index];
    }
}
