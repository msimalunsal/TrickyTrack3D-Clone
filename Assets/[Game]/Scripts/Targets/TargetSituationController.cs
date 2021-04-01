using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSituationController : MonoBehaviour
{
    enum TargetSituation {open , close};
    
    TargetSituation targetSituation;
    private void Start()
    {
        targetSituation= TargetSituation.close;
    }

    private void OnCollisionEnter(Collision other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        if(ball != null)
        {
            if(targetSituation == TargetSituation.close)
            {
                EventManager.OnObstacleOpen.Invoke();
                targetSituation = TargetSituation.open;
            }
            else
            {
                EventManager.OnObstacleClose.Invoke();
                targetSituation = TargetSituation.close;
            }
            
        }
    }
}
