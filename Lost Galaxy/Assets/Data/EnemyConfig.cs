using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemies/Enemy config", order = 0)]
public class EnemyConfig : ScriptableObject
{
    public float movementSpeed;
    public Sprite sprite;
    public bool isShooter;
    public float shootCadence;
    public float firstShootCadence;
    public int score;
}
