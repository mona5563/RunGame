using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCrush : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Trapに当たったら
        if(other.gameObject.CompareTag("Trap"))
        {
            //ゲームをプレイさせないようにする
            gameObject.GetComponentInParent<Player>().isGamePlaying = false;
        }
    }
}
