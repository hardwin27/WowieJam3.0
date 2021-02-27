using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    public bool isGrounded = false;

    void OnTriggerStay2D()
    {
        isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        isGrounded = false;
    }
}
