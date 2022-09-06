using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAround : Shooter
{
    public int numOfBullets = 5;
    private float offset = 0f;


    protected override void Shoot()
    {
        for (float i = offset; (i - offset) < 360f; i += 360 / numOfBullets)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, i));
        }
        offset = (offset + 10f) % 360f;
    }
}
