using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Animator animator;
    private Target parent;
    private void Start()
    {
        if(transform.parent.name != "Obstacles")
        {
            parent = transform.parent.gameObject.GetComponent<Target>();
        }
        else
        {
            parent = GetComponent<Target>();
        }
        animator = GetComponent<Animator>();
    }
    private void OnEnable() 
    {
        EventManager.OnObstacleOpen.AddListener(PlayObstacleOpenAnim);
        EventManager.OnObstacleClose.AddListener(PlayObstacleCloseAnim);
    }

    private void OnDisable() 
    {
        EventManager.OnObstacleOpen.RemoveListener(PlayObstacleOpenAnim);
        EventManager.OnObstacleClose.RemoveListener(PlayObstacleCloseAnim);
    }

    private void PlayObstacleOpenAnim()
    {
        if(parent.targetSituation == Target.TargetSituation.open)
        {
            animator.SetBool("isOpen" , true);
        }
    }

    private void PlayObstacleCloseAnim()
    {
        if(parent.targetSituation == Target.TargetSituation.close)
        {
            animator.SetBool("isOpen" , false);
        }
    }
}
