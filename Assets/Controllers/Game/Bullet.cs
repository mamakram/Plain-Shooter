using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100.0f;
    public float decay = 100.0f;
    public float decayUpgrade = 0f;
    private float distance = 0;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.forward);
        //transform.position+= Vector3.forward * speed * Time.deltaTime;
        Vector3 oldPosition = transform.position;
        transform.Translate((Vector3.right * speed * Time.deltaTime));
        distance += Vector3.Distance(oldPosition,transform.position);

        if (distance >= decay+decayUpgrade) { Destroy(gameObject); }
    }

    
}
