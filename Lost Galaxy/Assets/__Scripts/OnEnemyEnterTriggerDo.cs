using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyEnterTriggerDo : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] List<string> tagsToIgnore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var tags in tagsToIgnore)
        {
            if (collision.tag == tags)
            {
                return;
            }
        }
        action.Invoke();
    }

}
