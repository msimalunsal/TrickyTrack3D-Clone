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


    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        EventManager.OnPlayerWait.AddListener(() => isMove = false);
        EventManager.OnObstacleOpen.AddListener(() => isMove = true);
    }

    private void OnDisable()
    {
        EventManager.OnPlayerWait.RemoveListener(() => isMove = false);
        EventManager.OnObstacleOpen.RemoveListener(() => isMove = true);
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
        //rigidbody.velocity = new Vector3(0, 0, speed * Time.fixedDeltaTime * 50);
    }
}
