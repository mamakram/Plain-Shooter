using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnDeath : MonoBehaviour,DeathBehaviour
{
    public GameObject bulletPrefab;

    public void Died()
    {
        for(float i =0f;i<360f;i+=45)
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0,i));
    }
}
