﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Body
{
    [SerializeField]
    float moveForce;
    Vector2 moveDirection;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GoAstral();
        }
        
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        body.velocity = moveDirection * moveForce;
    }

    protected override void GoAstral()
    {
        body.velocity = Vector2.zero;
        base.GoAstral();
    }

    public void stopMoving() {
        body.velocity = new Vector2(0,0);  
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
