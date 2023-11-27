using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCrush : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Trap‚É“–‚½‚Á‚½‚ç
        if(other.gameObject.CompareTag("Trap"))
        {
            //ƒQ[ƒ€‚ğƒvƒŒƒC‚³‚¹‚È‚¢‚æ‚¤‚É‚·‚é
            gameObject.GetComponentInParent<Player>().isGamePlaying = false;
        }
    }
}
