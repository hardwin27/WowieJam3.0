using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField]
    protected bool isControlled;
    protected bool isAlive = true;

    protected Rigidbody2D body;

    MainCamera camera;

    [SerializeField]
    protected GameObject astralProjectionPrefabs;

    protected Animator animator;

    protected virtual void Start() 
    {
        body = GetComponent<Rigidbody2D>();
        enabled = isControlled;
        // camera.enabled = isControlled;
        animator = GetComponent<Animator>();
        camera = transform.parent.Find("MainCamera").GetComponent<MainCamera>();
        if (isControlled)
        {
            camera.SetPlayerTransform(transform);
        }
    }

    protected virtual void GoAstral()
    {
        // camera.enabled = false;

        GameObject astralProjection = Instantiate(astralProjectionPrefabs, transform.position, Quaternion.identity);
        astralProjection.transform.parent = transform.parent;
        enabled = false;
        // animator.SetFloat("Speed", 0.0f);
        
    }

    public void Dead()
    {
        isAlive = false;
        GoAstral();
    }
    public virtual bool GetIsAlive()
    {
        return isAlive;
    }
}
