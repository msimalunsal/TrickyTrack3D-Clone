using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSituationController : MonoBehaviour
{
    private Target situation;

    private void Start()
    {
        situation = transform.parent.gameObject.GetComponent<Target>();
        situation.targetSituation = Target.TargetSituation.close;
    }

    private void OnCollisionEnter(Collision other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        if(ball != null)
        {
            if(situation.targetSituation == Target.TargetSituation.close)
            {
                situation.targetSituation = Target.TargetSituation.open;
                EventManager.OnObstacleOpen.Invoke();
            }
            else
            {
                situation.targetSituation = Target.TargetSituation.close;
                EventManager.OnObstacleClose.Invoke();
            }
            
        }
    }
}
