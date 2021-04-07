using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if(player != null)
        {
            if(GetComponent<Animator>().GetBool("isOpen"))
            {
                player.Speed =  8f;
            }
            else
            {
                player.Speed =  2f;
            }
        }    
        else if(enemy != null)
        {
            if(GetComponent<Animator>().GetBool("isOpen"))
            {
                enemy.Speed =  8f;
            }
            else
            {
                enemy.Speed =  2f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        
        if(player != null)
        {
            player.Speed = 4f;
        }
        else if(enemy!=null)
        {
            enemy.Speed = 4f;
        }
    }
}
