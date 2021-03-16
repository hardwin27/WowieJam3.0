using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    GameObject bodyObject;
    void OnTriggerEnter2D(Collider2D other)
    {
        bodyObject = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        bodyObject = null;
    }

    public GameObject GetBody()
    {
        return bodyObject;
    }
}
