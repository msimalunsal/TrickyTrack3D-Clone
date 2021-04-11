using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if(gameObject.tag == "PlayerBall") return;
            EventManager.OnPlayerHit.Invoke();
        }
        else if(other.gameObject.GetComponent<EnemyMovement>() != null)
        {
            if(gameObject.tag == "EnemyBall") return;
            EventManager.OnEnemyHit.Invoke();
            Debug.Log("Enemy Hit!");
        }
    }
}
