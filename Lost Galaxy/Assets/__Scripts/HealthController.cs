using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int health;
    [SerializeField] private UnityEvent onZeroHealthActions;

    public void OnDamage(int damageAmout)
    {
        health -= damageAmout;
    }

    public void OnZeroHealth()
    {
        Debug.Log("Im dead!");
        if (onZeroHealthActions != null)
        {
            onZeroHealthActions.Invoke();
        }
    }
}
