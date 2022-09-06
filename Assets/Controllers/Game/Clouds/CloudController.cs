using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float maxY;
    public float maxX;
    public float cloudSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        maxY = Camera.main.GetComponent<Camera>().orthographicSize;
        maxX = maxY*Screen.width / Screen.height;
        //LoadClouds();
        foreach(Transform cloud in transform){
                cloud.position = new Vector3(Random.Range(-maxX,maxX),Random.Range(-maxY+5.0f, maxY-5.0f),0);
                cloud.gameObject.GetComponent<Cloud>().speed = Random.Range(5.0f,30.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform cloud in transform){
            if(cloud.position.x<-maxX-50.0f){
                cloud.position = new Vector3(Random.Range(maxX+50.0f,maxX+100.0f),Random.Range(-maxY+5.0f, maxY-5.0f),0);
                cloud.gameObject.GetComponent<Cloud>().speed = Random.Range(5.0f,30.0f);
            }
        }
    }

    /*
    void LoadClouds(){
        object[] loadedClouds = Resources.LoadAll ("Clouds",typeof(Sprite)) ;
        clouds = new GameObject[loadedClouds.Length];
        //this
        for(int x = 0; x< loadedClouds.Length;x++){
            clouds [x].GetComponent<SpriteRenderer>().sprite = (Sprite)loadedClouds [x];

        }
    }
    */
}
