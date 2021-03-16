using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralProjection : MonoBehaviour
{
    [SerializeField]
    float moveForce;
    Vector2 moveDirection;

    Rigidbody2D body;

    InteractionArea interactionArea;
    GameObject objectBody;

    MainCamera camera;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        interactionArea = transform.GetChild(0).GetComponent<InteractionArea>();
        camera = transform.parent.Find("MainCamera").GetComponent<MainCamera>();
        camera.playerTransform.gameObject.SendMessage("stopMoving");
        camera.SetPlayerTransform(transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            InfestBody();
        }
        
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
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
                camera.SetPlayerTransform(objectBody.transform);
                Destroy(gameObject);
            }
        }
    }
}
