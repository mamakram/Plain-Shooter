using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter: MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootRate = 1f;
    private bool shooting = true;
    private float shootTimer = 0f;

    public void StartShooting() { shooting = true; }
    public void StopShooting() { shooting = false; }
    public void Update() {
        if (shootTimer <= 0 && shooting)
        {
            Shoot();
            shootTimer = 1f;
        }

        shootTimer -= Time.deltaTime * shootRate;
    }
    protected abstract void Shoot();
}
