using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyProjectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Object.Destroy(gameObject);
        }
    }
}
