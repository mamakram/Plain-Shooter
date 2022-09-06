using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCos : Movement
{
    private float cosCenterY;
    public float amplitude = 2;
    public float frequency = 2;
    // Start is called before the first frame update
    void Start()
    {
        cosCenterY = transform.position.y;
    }



    public override void Move()
    {
            Vector2 pos = transform.position;
            float cos = Mathf.Cos(pos.x * frequency) * amplitude;
            pos.y = cosCenterY + cos;
            transform.position = pos;
    }

}
