using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Movement
{
    public float rotationSpeed = 100f;

    // Update is called once per frame
    public override void Move()
    {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    
}
