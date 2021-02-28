using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorilla : Body
{
    [SerializeField]
    float moveSpeed;
    float moveDirection;

    [SerializeField]
    float jumpVelocity;
    [SerializeField]
    float cayoteJumpDuration;
    bool jumpPressed = false;
    float jumpTimer = 0.0f;

    [SerializeField]
    GameObject groundTriggerObject;
    GroundTrigger groundTrigger;
    [SerializeField]
    InteractionArea punchArea;

    protected override void Start()
    {
        base.Start();
        groundTrigger = groundTriggerObject.GetComponent<GroundTrigger>();
        enabled = isControlled;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Punch();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        moveDirection = Input.GetAxisRaw("Horizontal");

        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(8f, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-8f, transform.localScale.y, transform.localScale.z);
        }
        
    }

    void FixedUpdate()
    {
        if (groundTrigger.isGrounded)
        {
            jumpTimer = cayoteJumpDuration;
        }
        else
        {
            if (jumpTimer >= 0)
            {
                jumpTimer -= Time.fixedDeltaTime;
            }
        }
        if (jumpPressed)
        {
            if (jumpTimer > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVelocity);
            }
        }

        body.velocity = new Vector2(moveDirection * moveSpeed, body.velocity.y);  
    }

    protected override void GoAstral()
    {
        base.GoAstral();
    }

    void Punch()
    {
        GameObject punchedObject = punchArea.GetBody();
        if (punchedObject.layer == 13)
        {
            Destroy(punchedObject);
        }
    }
}
