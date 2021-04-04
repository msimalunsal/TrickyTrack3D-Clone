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
        if(player != null &&  (int)targetSituation == (int)TargetSituation.close && GetComponent<Boost>() == null)
        {
            EventManager.OnPlayerWait.Invoke();
        }
        
    }
}
