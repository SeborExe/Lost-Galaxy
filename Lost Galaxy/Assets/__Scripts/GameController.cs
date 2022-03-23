using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private int playerScore;

    private void Awake()
    {
        Instance = this;
        playerScore = 0;
    }

    public void OnDied(GameObject deadObject, int score = 0)
    {
        playerScore += score;
    }
}
