using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;
    public float Speed
    {
        get 
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    
    private bool isMove = true;

    private void OnEnable()
    {
        EventManager.OnEnemyWait.AddListener(() => isMove = false);
        EventManager.OnObstacleOpen.AddListener(() => isMove = true);

    }

    private void OnDisable()
    {
        EventManager.OnEnemyWait.RemoveListener(() => isMove = false);
        EventManager.OnObstacleOpen.RemoveListener(() => isMove = true);
        
    }
    void Update()
    {
        if(isMove)
        {
            MovePlayer();            
        }
  
    }

    private void MovePlayer()
    {
        transform.position = new Vector3(transform.position.x , transform.position.y , transform.position.z + speed * Time.deltaTime);
    }
}
