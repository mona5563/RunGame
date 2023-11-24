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

    // Start is called before the first frame update
    void Start()
    {
        int seed = (int)System.DateTime.Now.Ticks;
        Random.InitState(seed);

        stageNum = firstStageNum - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        int playerPosIndex = (int)(player.position.z / stageSize);

        if(playerPosIndex + aheadStage > stageNum)
        {
            StageManager(playerPosIndex + aheadStage);
        }
    }

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

    GameObject MakeStage(int index)
    {
        //���̃X�e�[�W�������_���Ō��߂�
        int nextStage = Random.Range(0, grounds.Length);

        //�X�e�[�W�𐶐�����
        GameObject stageObject = (GameObject)Instantiate(grounds[nextStage], new Vector3(0, 0, index * stageSize), Quaternion.identity);

        return stageObject;
    }

    void DestroyStage()
    {
        GameObject oldStage = stageList[0];
        stageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
