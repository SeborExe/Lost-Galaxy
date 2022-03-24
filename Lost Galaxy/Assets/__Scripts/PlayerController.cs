using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour
{
    public Move moveComponent;
    public float speed;
    public Boundary boundary;
    [SerializeField] private List <Shooter> shooters;
    [SerializeField] private PlayerConfig config;

    private int powerLevel;
    private int unlockedCannons = 1;

    private void Start()
    {
        moveComponent.speed = speed;
        InputProvider.OnHasShoot += OnHasShoot;
        InputProvider.OnDirection += OnDirection;
    }

    private void OnDirection(Vector3 direction)
    {
        moveComponent.direction = direction;
    }

    private void OnHasShoot()
    {
        for (int i = 0; i < unlockedCannons; i++)
        {
            var shooter = shooters[i];
            shooter.DoShoot();
        }
    }

    public void AddToPowerLevel(int powerToAdd)
    {
        powerLevel += powerToAdd;
        var powerConfig = config.GetPowerConfig(powerLevel);
        unlockedCannons = powerConfig.cannonAmount;
    }

    public void OnPlayerDie()
    {
        GameController.Instance.OnPlayerDie();
    }

    private void Update()
    {
        float x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
        float y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
        transform.position = new Vector3(x, y);
    }
}
