using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum TargetSituation {open , close};
    
    public TargetSituation targetSituation;
    private void OnTriggerStay(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if(player != null &&  (int)targetSituation == (int)TargetSituation.close && GetComponent<Boost>() == null)
        {
            EventManager.OnPlayerWait.Invoke();
        }
        else if(enemy != null &&  (int)targetSituation == (int)TargetSituation.close && GetComponent<Boost>() == null && gameObject.tag != "DoubleDoor")
        {
            EventManager.OnEnemyWait.Invoke();
        }
        else if(enemy != null && (int)targetSituation == (int)TargetSituation.open && gameObject.tag == "DoubleDoor")
        {
            EventManager.OnEnemyWait.Invoke();
        }
        
    }
}
