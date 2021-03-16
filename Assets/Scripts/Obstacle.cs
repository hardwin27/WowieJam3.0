using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Body collidedBody;
    void OnTriggerEnter2D(Collider2D other)
    {
        collidedBody = other.gameObject.GetComponent<Body>();
        if (collidedBody.GetIsAlive())
        {
            collidedBody.Dead();
        }    
    }
}
