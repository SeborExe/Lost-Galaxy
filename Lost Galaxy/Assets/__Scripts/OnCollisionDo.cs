using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionDo : MonoBehaviour
{
    [SerializeField] private UnityEvent action;

    private GameObject collisionObj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObj = collision.gameObject;
        action.Invoke();
    }

    public void DestroyCollisionObj()
    {
        if (collisionObj != null)
        {
            Destroy(collisionObj);
        }
    }
}
