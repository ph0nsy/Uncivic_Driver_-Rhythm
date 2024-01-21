using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermnentRotation : MonoBehaviour
{

    public float tiltx = 15.0f; // rotación a realizar 
    // 
    void Update()
    {
        transform.Rotate(0, tiltx * Time.deltaTime, 0);
    }
}
