using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Movement
{
    public float speed;

    // Update is called once per frame
    public override void Move()
    {
            transform.position += -Vector3.right * speed * Time.deltaTime;
    }
}
