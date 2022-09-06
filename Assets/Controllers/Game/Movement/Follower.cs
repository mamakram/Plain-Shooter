using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Movement
{
    public Transform[] route;

    private int routeIndex = 1;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = route[0].position;
    }

    // Update is called once per frame
    public override void Move()
    {
        if (routeIndex < route.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, route[routeIndex].position, speed * Time.deltaTime);

            if (transform.position == route[routeIndex].position)
            {
                routeIndex++;
            }
        }
    }
}
