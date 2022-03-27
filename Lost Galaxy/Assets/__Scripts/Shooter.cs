using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private GameObject bullet;

    public bool isEnebled = true;

    public void DoShoot()
    {
        if (isEnebled)
            Instantiate(bullet, shootOrigin.position, shootOrigin.rotation);
    }

    public void EnableShoot(bool shouldEnable)
    {
        isEnebled = shouldEnable;
    }
}
