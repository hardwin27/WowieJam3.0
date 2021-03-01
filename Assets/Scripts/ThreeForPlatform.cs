using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeForPlatform : MonoBehaviour
{
    GameObject platform;

    void Start() 
    {
        platform = transform.GetChild(0).gameObject;
        platform.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        platform.SetActive(true);
        platform.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}
