using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionDo : MonoBehaviour
{
    [SerializeField] protected UnityEvent alwaysAction;

    protected GameObject collisionObj;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObj = collision.gameObject;
        alwaysAction.Invoke();
    }

    public virtual void DestroyCollisionObj()
    {
        if (collisionObj != null)
        {
            Destroy(collisionObj);
        }
    }
}
