/*EventLevelManager
 * 2023/11/29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLevelManager : MonoBehaviour
{
    //��Փx���������X�g
    [SerializeField]
    private List<float> levelRateList;

    //��Փx���X�g
    [SerializeField]
    private List<EventObjectManager> levelList;

    //���������v
    private float levelRateSum;

    // Start is called before the first frame update
    void Start()
    {
        levelRateSum = 0.0f;

        foreach (float rate in levelRateList)
        {
            //��Փx�����������v����
            levelRateSum += rate;
        }
    }

    /// <summary>
    /// ��������Prefab�I�u�W�F�N�g���擾����
    /// </summary>
    /// <param name="levelRate">��Փx������</param>
    /// <param name="eventRate">�C�x���g������</param>
    /// <returns></returns>
    public GameObject GetPrefabObject(float levelRate, float eventRate)
    {
        GameObject ret = null;
        float getRate = levelRate;

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
        getRate *= levelRateSum;

        int rankObjIndex = 0;
        EventObjectManager selectObjectManager = null;

        //  ���[���b�g���œ������������N�𔻒�
        foreach (float rate in levelRateList)
        {
            getRate -= rate;
            if (getRate <= 0.0f)
            {
                //  ���[���b�g�̓��������ꏊ���o���̂ŁA�Y���}�l�[�W�����m�ۂ��ă��[�v���I����
                selectObjectManager = levelList[rankObjIndex];
                break;
            }
            rankObjIndex++;
        }

        //  �������Ȓl�ł���΁A�Ō�̃I�u�W�F�N�g�ɂ���
        if (selectObjectManager == null)
        {
            selectObjectManager = levelList[levelList.Count - 1];
        }

        //  �擾������Փx����Y������prefab�I�u�W�F�N�g���l������
        GameObject originObject = selectObjectManager.GetPrefabObject(eventRate);
        ret = Instantiate(originObject);

        //  ���W�����S�Ɍ��_�Ƃ���
        ret.transform.position = Vector3.zero;
        ret.transform.localPosition = Vector3.zero;

        return ret;
    }
}
