using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jitter : MonoBehaviour
{
    public float frequency=1;
    public float jitterAmount=1;
    public float despVertical=0;
    public bool  leftRightJitter=false;
    Vector3 position;
    float timestep=0;

    // Start is called before the first frame update
    void Start()
    {
        this.position = this.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timestep+=Time.deltaTime*frequency; 
        position = leftRightJitter ? 
            Vector3.left *(despVertical+ (jitterAmount*Mathf.Cos(timestep))): 
            Vector3.up *(despVertical+ (jitterAmount*Mathf.Cos(timestep)));
        this.transform.position=position;
    }
}
