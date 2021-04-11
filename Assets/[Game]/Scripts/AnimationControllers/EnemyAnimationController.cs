using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventManager.OnEnemyWait.AddListener(() => animator.SetBool("isWait" , true));
        EventManager.OnObstacleOpen.AddListener(() => animator.SetBool("isWait",false));

    }

    private void OnDisable()
    {
        EventManager.OnEnemyWait.RemoveListener(() => animator.SetBool("isWait" , true));
        EventManager.OnObstacleOpen.RemoveListener(() => animator.SetBool("isWait",false));

    }


}
