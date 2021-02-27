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
            GoAstral();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        moveDirection = Input.GetAxis("Horizontal");
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

    // protected override void SetIsAlive()
    // {
    //     base.SetIsAlive();
    // }
    // protected override bool GetIsAlive()
    // {
    //     return base.SetIsAlive();
    // }
}
