using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventManager.OnPlayerWait.AddListener(() => animator.SetBool("isWait" , true));
        EventManager.OnObstacleOpen.AddListener(() => animator.SetBool("isWait",false));
    }

    private void OnDisable()
    {
        EventManager.OnPlayerWait.RemoveListener(() => animator.SetBool("isWait" , true));
        EventManager.OnObstacleOpen.RemoveListener(() => animator.SetBool("isWait",false));
        
    }


}
