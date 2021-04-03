using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetSituationController target;
    private void OnTriggerStay(Collider other) {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null &&  (int)target.targetSituation == (int)TargetSituationController.TargetSituation.close)
        {
            EventManager.OnPlayerWait.Invoke();
        }
    }
}
