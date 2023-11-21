/*Sweeper
 * 2023/11/21
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            //�uGround�v�^�O�̃I�u�W�F�N�g�ɓ���������I�u�W�F�N�g������
            Destroy(collision.gameObject);
        }
    }
}
