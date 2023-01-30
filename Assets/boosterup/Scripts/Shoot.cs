using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    public float rateOfFire = 2f;
    [SerializeField] Transform shootingPoint;

    public float GetRateOfFire()
    {
        return rateOfFire;
    }


    public void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
