using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        EventManager.OnPlayerWait.AddListener(() => isMove = false);
        EventManager.OnObstacleOpen.AddListener(() => isMove = true);
        EventManager.OnPlayerHit.AddListener(() => isMove = false);
        EventManager.OnPlayerHit.AddListener(() => this.Wait(1.5f,() => isMove = true));
    }

    private void OnDisable()
    {
        EventManager.OnPlayerWait.RemoveListener(() => isMove = false);
        EventManager.OnObstacleOpen.RemoveListener(() => isMove = true);
        EventManager.OnPlayerHit.RemoveListener(() => isMove = false);
        EventManager.OnPlayerHit.RemoveListener(() => this.Wait(1.5f,() => isMove = true));
        

    }
    // Update is called once per frame
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
