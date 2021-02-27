using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField]
    protected bool isControlled;
    protected bool isAlive = true;

    protected Rigidbody2D body;

    [SerializeField]
    protected GameObject astralProjectionPrefabs;

    protected virtual void Start() 
    {
        body = GetComponent<Rigidbody2D>();
    }

    protected virtual void GoAstral()
    {
        GameObject astralProjection = Instantiate(astralProjectionPrefabs, new Vector3(transform.position.x, transform.position.y + 1.0f, 0.0f), Quaternion.identity);
        astralProjection.transform.parent = null;

        enabled = false;
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
