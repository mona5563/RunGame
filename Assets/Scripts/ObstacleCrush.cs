using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCrush : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Trap�ɓ���������
        if(other.gameObject.CompareTag("Trap"))
        {
            //�Q�[�����v���C�����Ȃ��悤�ɂ���
            gameObject.GetComponentInParent<Player>().isGamePlaying = false;
        }
    }
}
