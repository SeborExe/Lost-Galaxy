using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyEnterTriggerDo : MonoBehaviour
{
    [SerializeField] private UnityEvent alwaysAction;
    [SerializeField] private UnityEvent unIgnoredActions;
    [SerializeField] List<string> tagsToIgnore;

    private void OnTriggerEnter2D(Collider2D collision)
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

}
