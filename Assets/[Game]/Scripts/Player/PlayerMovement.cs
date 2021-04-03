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
    

    private void OnEnable()
    {
        EventManager.OnPlayerWait.AddListener(() => speed = 0f);
        EventManager.OnObstacleOpen.AddListener(() => speed = 2f);
    }

    private void OnDisable()
    {
        EventManager.OnPlayerWait.RemoveListener(() => speed = 0f);
        EventManager.OnObstacleOpen.RemoveListener(() => speed = 2f);

        
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position = new Vector3(transform.position.x , transform.position.y , transform.position.z + speed * Time.deltaTime);
    }
}
