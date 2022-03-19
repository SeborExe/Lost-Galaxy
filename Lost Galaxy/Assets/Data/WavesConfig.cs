using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Enemies/Wave config", order = 0)]
public class WavesConfig : ScriptableObject
{
    [Serializable]
    public class EachEnemyConfig
    {
        public EnemyController enemyPrefab;
        public Vector3 spawnReferencePosition;
        public bool useSpecificXPosition;
        public EnemyConfig config;
    }

    public List<EachEnemyConfig> enemies;
    public float cadance;
}
