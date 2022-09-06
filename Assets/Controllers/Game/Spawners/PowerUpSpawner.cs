using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;

    public float dropProbability = 0.0001f;

    // Update is called once per frame
    void Update()
    {
        if (!GameController.paused)
        {
            //Debug.Log(rand);
            if (Random.Range(0f, 1.0f) < dropProbability)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Length)]);
            }
        }
    }
}
