using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
 
    public float spawnRate = 3f;
    private float spawnTimer = 0f;
    public int numOfDrones = 100;
    private int dronesLeft;
    public GameObject drone;
    public GameObject boss;
    private bool spawnDrones = true;
    public int timeToSwitch = 20;
    //private bool cos = false;
    public Transform[] route1;
    public Transform[] route2;

    void Start()
    {
        dronesLeft = numOfDrones;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameController.paused)
        {
            if (spawnTimer <= 0 && spawnDrones && dronesLeft>0)
            {
                GameObject spawned = Instantiate(drone, new Vector3(250, 0, 0), Quaternion.Euler(0, 0, 0));
                spawned.GetComponent<Follower>().route = dronesLeft < numOfDrones/2?route2:route1;
                
                //if (cos) { spawned.GetComponent<MoveSin>().switchToCos = true; }
                spawnTimer = 1f;
                dronesLeft--;
                /*
                if (timeToSwitch == 0)
                {
                    timeToSwitch = 20;
                    cos = !cos;
                }
                timeToSwitch -= 1;
                */
            }
            spawnTimer -= Time.deltaTime * spawnRate;

            

            if(dronesLeft == 0)
            {
                SpawnBoss();
                dronesLeft--;
            }
        }
    }

    public void StopDrones()
    {
        spawnDrones = false;
    }

    public void StartDrones()
    {
        spawnDrones=true;
    }

    public void SpawnBoss()
    {
        GameObject obj = Instantiate(boss, new Vector3(220, 0, 0), Quaternion.Euler(0, 0, 0));
        obj.GetComponent<Boss>().SetSpawner(this);
    }

    public void BossDied()
    {
        GetComponent<GameController>().GameOver();
    }

}
