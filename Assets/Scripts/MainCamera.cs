using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
    }
}
