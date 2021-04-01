using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {

        PlayerMovement player = other.GetComponent<PlayerMovement>();
        
        if(other!=null)
        {
            //if()
            player.Speed = player.Speed/2;
        }
    }
}
