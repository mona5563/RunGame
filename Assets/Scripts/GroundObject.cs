/*GroundObject
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObject : MonoBehaviour
{
    //�C�x���g�����ʒu���X�g
    [SerializeField] private List<GameObject> eventPointList;

    /// <summary>
    /// �C�x���g�ʒu���擾����
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject GetEventPoint(int index)
    {
        int getIndex = index;

        //Index���s����������␳����
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
    /// �C�x���g�ʒu�̑���
    /// </summary>
    /// <returns></returns>
    public int GetEventPointCount()
    {
        return eventPointList.Count;
    }
}
