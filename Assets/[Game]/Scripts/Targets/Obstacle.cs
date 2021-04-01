using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
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
        animator.SetBool("isOpen" , true);
    }

    private void PlayObstacleCloseAnim()
    {
        animator.SetBool("isOpen" , false);
    }
}
