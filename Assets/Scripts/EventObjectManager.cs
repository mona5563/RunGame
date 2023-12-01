/*EventObjectManager
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObjectManager : MonoBehaviour
{
    //�C�x���g���������X�g
    [SerializeField]
    private List<float> eventRateList;

    //����������C�x���g���X�g
    [SerializeField]
    private List<GameObject> eventList;

    //�C�x���g���������v
    private float eventRateSum;

    // Start is called before the first frame update
    void Start()
    {
        eventRateSum = 0.0f;

        foreach (float rate in eventRateList)
        {
            //���X�g���̔����������v����
            eventRateSum += rate;
        }
    }

    public GameObject GetPrefabObject(float eventRate)
    {
        GameObject ret = null;
        float getRate = eventRate;

        //  ���[�g���s���Ȓl��������␳����
        if (getRate < 0.0f)
        {
            getRate = 0.0f;
        }

        if (getRate > 1.0f)
        {
            getRate = 1.0f;
        }

        //  ���[�g�����[���b�g���f�ł���`�ɕϊ�
        getRate *= eventRateSum;

        int eventObjIndex = 0;

        //  ���[���b�g���œ��������C�x���g�𔻒�
        foreach (float rate in eventRateList)
        {
            getRate -= rate;
            if (getRate <= 0.0f)
            {
                //  ���[���b�g�̓��������ꏊ���o���̂ŁA�Y���C�x���g���m�ۂ��ă��[�v���I����
                ret = eventList[eventObjIndex];
                break;
            }
            eventObjIndex++;
        }

        //  �������Ȓl�ł���΁A�Ō�̃I�u�W�F�N�g�ɂ���
        if (ret == null)
        {
            ret = eventList[eventList.Count - 1];
        }

        return ret;
    }
}
