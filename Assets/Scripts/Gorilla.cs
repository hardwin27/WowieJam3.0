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

    bool isOnAction = false;

    protected override void Start()
    {
        base.Start();
        groundTrigger = groundTriggerObject.GetComponent<GroundTrigger>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Punch());
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        if (isOnAction)
        {
            moveDirection = 0.0f;
        }
        else 
        {
            moveDirection = Input.GetAxisRaw("Horizontal");
        }

        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(2f, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-2f, transform.localScale.y, transform.localScale.z);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        
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

    IEnumerator Punch()
    {
        isOnAction = true;
        animator.SetBool("IsPunching", isOnAction);
        yield return new WaitForSeconds(0.5f);
        GameObject punchedObject = punchArea.GetBody();
        if (punchedObject != null)
        {
            if (punchedObject.layer == 13)
            {
                Destroy(punchedObject);
            }
        }
        
        isOnAction = false;
        animator.SetBool("IsPunching", isOnAction);
    }
}
