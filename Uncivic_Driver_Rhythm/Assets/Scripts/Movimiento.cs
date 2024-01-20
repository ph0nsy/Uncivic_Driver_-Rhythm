using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    Vector3 mov;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");   
        mov = this.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {   
        //X^2+y^2=R
        int R = 5;
        t+=2*Time.deltaTime;
        mov = Vector3.left *2*R*Mathf.Sin(t)-Vector3.up *R*Mathf.Cos(2*t);

        this.transform.position=mov;
    }
}
