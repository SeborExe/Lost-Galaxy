using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public EnemyConfig config;
    private Move move;
    private SpriteRenderer renderer;

    private void Start()
    {
        move = GetComponent<Move>();
        renderer = GetComponentInChildren<SpriteRenderer>();
        if (move != null)
        {
            move.speed = config.movementSpeed;
        }

        if (config.sprite != null)
        {
            renderer.sprite = config.sprite;
        }
    }
}
