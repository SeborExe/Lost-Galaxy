using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private GameObject bullet;

    public void DoShoot()
    {
        Instantiate(bullet, shootOrigin.position, shootOrigin.rotation);
    }
}
