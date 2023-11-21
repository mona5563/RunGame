/*GenerateGrounds
 * 2023/11/21
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrounds : MonoBehaviour
{
    //Ground�I�u�W�F�N�g�i�[�p�z��
    [SerializeField] GameObject[] ground;
    //Ground�I�u�W�F�N�g�𐶐�����Z���̈ʒu(�ŏ��ɐ�������ʒu��z80�Ƃ���)
    [SerializeField] int zPos = 80;
    //��ɐ������Ȃ��悤��������t���O
    [SerializeField] bool creatingGround = false;
    //��������Ground�I�u�W�F�N�g�̔ԍ�
    [SerializeField] int groundNum;
    //��������Ground�I�u�W�F�N�g��Z�ʒu�̕ω���
    private int addZPos = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!creatingGround)
        {
            //�������Ȃ�
            creatingGround = true;
            //�R���[�`�����Ăяo��
            StartCoroutine(GenerateGround());
        }
    }

    /// <summary>
    /// �R���[�`�����g�p����Ground�I�u�W�F�N�g�������_���ɐ�������
    /// </summary>
    /// <returns></returns>
    IEnumerator GenerateGround()
    {
        //��������Ground�I�u�W�F�N�g�������_���Ō��߂�
        groundNum = Random.Range(0, 4);
        //�I�u�W�F�N�g�𐶐�����
        Instantiate(ground[groundNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += addZPos;
        //�R���[�`����5�b�Ԓ�~������
        yield return new WaitForSeconds(5);
        //�����������������Ƃ�m�点��
        creatingGround = false;
    }
}
