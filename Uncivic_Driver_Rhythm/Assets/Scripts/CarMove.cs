using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{


    public int delta=1;
    Vector3 mov;
    float t = 0;

    public float CAR_SIZE=5;

    Vector3 sphereCoords;

    public GameObject worldSphere;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");   
        mov = this.GetComponent<Transform>().position;
        sphereCoords = this.worldSphere.GetComponent<Transform>().position;
        
    }

    

    // Update is called once per frame
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {   
        int R = 50;
        
        
        if(this.gameObject.GetComponent<BeatCheck>().checking 
        && Input.GetAxis("Horizontal")!=0){
            Debug.Log("AAAAAAAAAAAAAA");
            delta=5;
        } 

        t+=Time.deltaTime;

        mov =     Vector3.forward *(sphereCoords.z-CAR_SIZE/2  + (R*Mathf.Cos(delta*t)))
                + Vector3.up * (sphereCoords.y+CAR_SIZE/2 + (R*Mathf.Sin(delta*t)))
                + Vector3.right * (mov.x);
        this.transform.position=mov;
    }
}
