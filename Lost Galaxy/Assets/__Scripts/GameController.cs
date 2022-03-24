using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public delegate void EnemyDied(GameObject corps);
    public event EnemyDied OnEnemyDied;

    [SerializeField] private PlayerController player;
    [SerializeField] private SpawnerController spawner;

    private int playerScore;

    private void Awake()
    {
        Instance = this;
        playerScore = 0;
    }

    public void OnDied(GameObject deadObject, int score = 0)
    {
        playerScore += score;
        player.AddToPowerLevel(1);

        if (OnEnemyDied != null)
        {
            OnEnemyDied.Invoke(gameObject);
        }
    }

    public void OnPlayerDie()
    {

    }
}
