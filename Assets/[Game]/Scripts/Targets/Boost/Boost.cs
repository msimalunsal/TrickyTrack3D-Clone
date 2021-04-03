using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null)
        {
            if(GetComponent<Animator>().GetBool("isOpen"))
            {
                player.Speed =  4f;
            }
            else
            {
                player.Speed =  1f;
            }

        }    
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        
        if(player != null)
        {
            player.Speed = 2f;
        }
    }
}
