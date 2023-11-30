/*GroundObject
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> eventPointList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetEventPoint(int index)
    {
        int getIndex = index;

        //IndexÇ™ïsê≥ÇæÇ¡ÇΩÇÁï‚ê≥Ç∑ÇÈ
        if(getIndex < 0)
        {
            getIndex = 0;
        }
        if(getIndex >= eventPointList.Count)
        {
            getIndex = eventPointList.Count - 1;
        }

        return eventPointList[getIndex];
    }

    public int GetEventPointCount()
    {
        return eventPointList.Count;
    }
}
