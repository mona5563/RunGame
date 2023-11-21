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
            //「Ground」タグのオブジェクトに当たったらオブジェクトを消す
            Destroy(collision.gameObject);
        }
    }
}
