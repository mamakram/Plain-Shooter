using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : Movement
{
    private float sinCenterY;
    public float amplitude = 2;
    public float frequency = 2;
    public bool switchToCos = false;
    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }



    public override void Move()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if(switchToCos)
        {
            sin = Mathf.Cos(pos.x * frequency) * amplitude;
        }
            pos.y = sinCenterY + sin;
            transform.position = pos;
    }

}
