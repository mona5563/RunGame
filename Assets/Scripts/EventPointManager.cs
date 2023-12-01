/*EventPointManager
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPointManager : MonoBehaviour
{
    //�C�x���g�o���ʒu���X�g
    [SerializeField] List<GameObject> eventPointList;

    /// <summary>
    /// ���C�x���g�|�C���g�����擾����
    /// </summary>
    /// <returns></returns>
    public int GetEventPointSize()
    {
        return eventPointList.Count;
    }

    /// <summary>
    /// �C�x���g���o��������|�C���g���擾����
    /// </summary>
    /// <param name="index">���X�g�ԍ�</param>
    /// <returns></returns>
    public GameObject GetEventPoint(int index)
    {
        if (index < 0 || index >= eventPointList.Count)
        {
            //�w�肳�ꂽ�C���f�b�N�X���s���Ȓl������
            return null;
        }

        //�w�肳�ꂽ�C���f�b�N�X��GameObject��Ԃ�
        return eventPointList[index];
    }
}
