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
        foreach (var shooter in shooters)
        {
            shooter.DoShoot();
        }
    }

    private void Update()
    {
        float x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
        float y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
        transform.position = new Vector3(x, y);
    }
}
