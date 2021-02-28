using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralProjection : MonoBehaviour
{
    [SerializeField]
    float moveForce;
    Vector2 moveDirection;

    Rigidbody2D body;

    // Camera camera;

    InteractionArea interactionArea;
    GameObject objectBody;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        interactionArea = transform.GetChild(0).GetComponent<InteractionArea>();
        // camera.enabled = true;
        // camera = GetComponent<Camera>();
        // camera.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            InfestBody();
        }
        
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        body.velocity = moveDirection * moveForce;    
    }

    void InfestBody()
    {
        objectBody = interactionArea.GetBody();
        if (objectBody != null)
        {
            if (objectBody.GetComponent<Body>().GetIsAlive())
            {
                objectBody.GetComponent<Body>().enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
