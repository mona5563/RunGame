/*GenerateGrounds
 * 2023/11/21
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrounds : MonoBehaviour
{
    //�X�e�[�W�T�C�Y
    int stageSize = 20;
    //��������X�e�[�W�̔ԍ�
    int stageNum;

    //�v���C���[��Transform
    [SerializeField] Transform player;
    //Ground�I�u�W�F�N�g�i�[�p�z��
    [SerializeField] GameObject[] grounds;
    //�X�^�[�g���̃X�e�[�W�ԍ�
    [SerializeField] int firstStageNum;
    //���O�ɐ�������X�e�[�W
    [SerializeField] int aheadStage;
    //���������X�e�[�W�̃��X�g
    [SerializeField] List<GameObject> stageList = new List<GameObject>();

    //�C�x���g�̓�Փx�}�l�[�W���[
    [SerializeField] EventLevelManager levelManager;
    //��Փx�p�m�C�Y�����߂邽�߂̃I�N�^�[�u��
    [SerializeField] private int levelOctaves;
    //�C�x���g�I�u�W�F�N�g�p�m�C�Y�����߂邽�߂̃I�N�^�[�u��
    [SerializeField] private int eventObjectOctaves;
    //��Փx�p�m�C�Y�̑��x
    [SerializeField] private float levelNoiseSpeed;
    //�C�x���g�I�u�W�F�N�g�p�m�C�Y�̑��x
    [SerializeField] private float eventObjectNoiseSpeed;

    //��Փx�p�m�C�Y
    private Noise levelNoise;
    //�C�x���g�I�u�W�F�N�g�p�m�C�Y
    private Noise eventObjectNoise;

    //��Փx�p�m�C�Y�ʒu
    private float levelNoisePos;
    //�C�x���g�I�u�W�F�N�g�p�m�C�Y�ʒu
    private float eventObjectNoisePos;

    // Start is called before the first frame update
    void Start()
    {
        //��Փx�ƃI�u�W�F�N�g��ω������邽�߂̃p�[�����m�C�Y���쐬
        levelNoise = new Noise();
        eventObjectNoise = new Noise();

        //�V�[�h�l�̐ݒ�
        int seed = (int)System.DateTime.Now.Ticks;
        Random.InitState(seed);

        //�ŏ��̃X�e�[�W�̐���
        stageNum = firstStageNum - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̈ʒu���X�e�[�W�̂ǂ�������o��
        int playerPosIndex = (int)(player.position.z / stageSize);

        //�X�e�[�W�𒴂�����
        if(playerPosIndex + aheadStage > stageNum)
        {
            //�V�����X�e�[�W�𐶐�����ׂɃ}�l�[�W���[���Ă�
            StageManager(playerPosIndex + aheadStage);
        }
    }

    /// <summary>
    /// �X�e�[�W���Ǘ�����
    /// </summary>
    /// <param name="maps"></param>
    void StageManager(int maps)
    {
        if(maps <= stageNum)
        {
            return;
        }
        
        //�w�肵���X�e�[�W�܂ō쐬����
        for(int i = stageNum + 1; i <= maps; i++)
        {
            GameObject stage = MakeStage(i);
            stageList.Add(stage);
        }

        //�Â��X�e�[�W���폜����
        while(stageList.Count > aheadStage + 1)
        {
            DestroyStage();
        }

        stageNum = maps;
    }

    /// <summary>
    /// �X�e�[�W�𐶐�����
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    GameObject MakeStage(int index)
    {
        //���̃X�e�[�W�������_���Ō��߂�
        int nextStage = Random.Range(0, grounds.Length);

        //�X�e�[�W�𐶐�����
        GameObject stageObject = (GameObject)Instantiate(grounds[nextStage], new Vector3(0, 0, index * stageSize), Quaternion.identity);

        //�C�x���g�𐶐�����
        CreateEventPoints(stageObject);

        return stageObject;
    }

    /// <summary>
    /// �X�e�[�W���폜����
    /// </summary>
    void DestroyStage()
    {
        GameObject oldStage = stageList[0];
        stageList.RemoveAt(0);
        Destroy(oldStage);
    }

    /// <summary>
    /// �C�x���g�|�C���g���쐬����
    /// </summary>
    /// <param name="grandObject"></param>
    private void CreateEventPoints(GameObject grandObject)
    {
        GroundObject ground = grandObject.GetComponent<GroundObject>();
        int maxEventCount = ground.GetEventPointCount();

        //��������C�x���g���̏����10�ɂ���
        if (maxEventCount > 10)
        {
            maxEventCount = 10;
        }

        //  �z�u����C�x���g�̐�
        //���������̕΂�����Ȃ����邽��10�|����
        int eventCount = Random.Range(50, maxEventCount * 10);
        eventCount /= 10;

        //�C�x���g��ݒu����ꏊ�ƃC�x���g���쐬
        List<bool> eventList = new List<bool>();
        int eventListMaxIndex = ground.GetEventPointCount();

        for (int i = 0; i < eventListMaxIndex; i++)
        {
            eventList.Add(false);
        }

        for (int i = 0; i < eventCount; i++)
        {
            // �����_���ňʒu����
            int randomIndex = Random.Range(0, eventListMaxIndex);

            while (eventList[randomIndex])
            {
                //���łɏꏊ�����܂��Ă�����ēx�����_���Ō��߂�
                randomIndex = Random.Range(0, eventListMaxIndex);
            }

            //�u���ꏊ�����܂���
            eventList[randomIndex] = true;

            //�C�x���g���쐬���郌�x���̌�����s��
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

            //  �C�x���g�����I�u�W�F�N�g
            GameObject getEventIndex = ground.GetEventPoint(randomIndex);

            //  ��Փx�ʃI�u�W�F�N�g
            GameObject newEvent = levelManager.GetPrefabObject(levelNoiseValue, eventObjectNoiseValue);

            newEvent.SetActive(true);
            newEvent.transform.SetParent(getEventIndex.transform);
            newEvent.transform.position = Vector3.zero;
            newEvent.transform.localPosition = Vector3.zero;
        }
    }
}
