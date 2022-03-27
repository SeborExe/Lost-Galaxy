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

        if (health <= 0)
        {
            OnZeroHealth();
        }
    }

    public void OnZeroHealth()
    {
        if (onZeroHealthActions != null)
        {
            onZeroHealthActions.Invoke();
        }
    }
}
