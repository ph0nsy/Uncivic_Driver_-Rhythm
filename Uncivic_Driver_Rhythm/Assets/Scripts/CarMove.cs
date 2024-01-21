using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{

    Vector3 mov;
    float t = 0;

    public float CAR_SIZE=5;

    Vector3 sphereCoords;

    public GameObject worldSphere;

    // Start is called before the first frame update
    void Start()
    {
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
        t+=Time.deltaTime;
        
        mov =     Vector3.forward *(sphereCoords.z-CAR_SIZE/2  + (R*Mathf.Cos(t)))
                + Vector3.up * (sphereCoords.y+CAR_SIZE/2 + (R*Mathf.Sin(t)))
                + Vector3.right * (mov.x);

        this.transform.position=mov;
        
    }
}
