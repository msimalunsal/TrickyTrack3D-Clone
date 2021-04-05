﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            EventManager.OnPlayerHit.Invoke();
        }
    }
}
