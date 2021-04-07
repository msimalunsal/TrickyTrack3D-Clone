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
