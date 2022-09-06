using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Object.Destroy(gameObject);
        }
    }
}

public enum PowerUpType
{
    Speed,
    Distance,
    TripleShot,
    Health,
    Shield
}