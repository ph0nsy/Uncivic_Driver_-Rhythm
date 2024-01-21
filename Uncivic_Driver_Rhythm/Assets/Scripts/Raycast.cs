using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    int frames =0;
     public bool isCounting=false;
    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1<<8;
       

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out hit, Mathf.Infinity, layerMask))
        {
            if (!isCounting){
                Debug.Log("Did Hit");
                isCounting=true;
            } else {
                isCounting=false;
                Debug.Log("end: " + frames);
                frames = 0;
            }
        }
        
        if(isCounting){++frames;}
    }
}
