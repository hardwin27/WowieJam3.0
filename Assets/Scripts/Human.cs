using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Body
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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GoAstral();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        moveDirection = Input.GetAxis("Horizontal");

        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            if (jumpTimer > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVelocity);
            }
        }
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
