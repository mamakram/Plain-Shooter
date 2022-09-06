using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : Movement
{
    public float speed = 1f;
    public Vector3 target;


    // Update is called once per frame
    public override void Move()
    {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

}
