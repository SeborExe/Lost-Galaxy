using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyEnterTriggerDo : OnCollisionDo
{
    [SerializeField] private UnityEvent unIgnoredActions;
    [SerializeField] List<string> tagsToIgnore;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        alwaysAction.Invoke();
        foreach (var tags in tagsToIgnore)
        {
            if (collision.tag == tags)
            {
                return;
            }
        }
        unIgnoredActions.Invoke();
    }

    public override void DestroyCollisionObj()
    {
        Debug.Log("Do nothing");
    }

}
