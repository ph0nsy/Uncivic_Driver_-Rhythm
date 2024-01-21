using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    [SerializeField]
    public GameObject birdFlip; 
    Image flip;
    [SerializeField]
    public GameObject playerLights;
    Light largas;
    // Start is called before the first frame update
    void Start()
    {
        flip = birdFlip.GetComponent<Image>();
        largas = playerLights.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        if(input < 0)
            flip.enabled = true;
        else if(input > 0)
            largas.enabled = true;      
        else {
            largas.enabled = false;
            flip.enabled = false;
        }
            
    }
}
