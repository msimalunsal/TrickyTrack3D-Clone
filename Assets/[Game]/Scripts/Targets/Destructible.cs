using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    public GameObject ballList;
    private void OnCollisionEnter(Collision other) {
        var ball =other.gameObject.GetComponent<Ball>();
        if(ball!=null){
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        for (int i = 0; i < ballList.transform.childCount; i++)
        {
            ballList.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }
       
    }
}
