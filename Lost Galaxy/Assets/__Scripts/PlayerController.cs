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

    public Transform shootOrigin;
    public GameObject bullet;

    private void Start()
    {
        moveComponent.speed = speed;
        InputKeyboardListener.Instance.OnHasShoot += OnHasShoot;
    }

    private void OnHasShoot()
    {
        Instantiate(bullet, shootOrigin, false);
    }

    private void Update()
    {
        moveComponent.direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), transform.position.z);

        float x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
        float y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
        transform.position = new Vector3(x, y);
    }
}
