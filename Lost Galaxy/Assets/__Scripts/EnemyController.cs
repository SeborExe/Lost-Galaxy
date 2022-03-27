using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public EnemyConfig config;
    private Move move;
    private SpriteRenderer renderer;
    private Shooter[] shooters;

    private void Start()
    {
        move = GetComponent<Move>();
        renderer = GetComponentInChildren<SpriteRenderer>();
        if (move != null)
        {
            move.speed = config.movementSpeed;
        }

        if (config.sprite != null && renderer != null)
        {
            renderer.sprite = config.sprite;
        }

        if (config.isShooter)
        {
            shooters = GetComponentsInChildren<Shooter>();
            if (shooters != null && shooters.Length > 0)
            {
                StartCoroutine(ShootForever());
            }
        }
    }

    public void OnDie()
    {
        Debug.Log("Im dead");
        GameController.Instance.OnDied(gameObject, config.score);
    }

    private IEnumerator ShootForever()
    {
        yield return new WaitForSeconds(config.firstShootCadence);
        while (true)
        {
            foreach (var shooter in shooters)
            {
                shooter.DoShoot();
            }
            yield return new WaitForSeconds(config.shootCadence);
        }
    }
}
