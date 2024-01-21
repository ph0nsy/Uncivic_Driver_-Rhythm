using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BeatCheck : MonoBehaviour
{

    // Active frame constants
    public int CHECK_FRAMES = 15;
    public int GOOD_FRAMES = 10;
    public int EXCELLENT_FRAMES = 4;
    public int CHECK_BAD_FRAMES;
    public int CHECK_GOOD_FRAMES;


    public int framecount;
    public bool checking = false;
    public bool isFlip = false;
    public int points;

    //public GameObject textScreen;

    private Transform hit_block=null;

    GameManager gameManager;
    Image accuracy;

    // Start is called before the first frame update
    void Start()
    {  
        Application.targetFrameRate=60;
        this.CHECK_BAD_FRAMES = CHECK_FRAMES-GOOD_FRAMES;
        this.CHECK_GOOD_FRAMES = (GOOD_FRAMES-EXCELLENT_FRAMES)/2;
        this.framecount=0;
        this.checking=false;
        this.points=0;
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        accuracy = GameObject.Find("Canvas/Accuracy").GetComponent<Image>();
        //textScreen = finalScore.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        raycast();

        //0 es nada, 1 es dcha y -1 izq
        float input = Input.GetAxis("Horizontal");

        if(this.checking){

            if(input!=0 && isCorrectAction(input)){
                this.checking=false;
                this.points = checkFrame(framecount);
                
            }
            if(framecount >= CHECK_FRAMES){
                this.checking=false;
                this.points=-1;
                Debug.Log("TOO LATE");
            }
            if(!isCorrectAction(input)){
                this.checking=false;
                this.points=-1;
                Debug.Log("FUCKED UP");
            }

            ++framecount;
        }
        // textScreen.GetComponent<Text>().text= "Score: " + this.points;
        
    }


    void raycast() {
         // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1<<8;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(hit.transform);
            if(hit_block==null || hit_block==hit.transform){
                hit_block = hit.transform;       
                // Debug.Log("---------------------------------------------------------------");
                this.checking=true;
                this.framecount=0;
            }

            if(hit_block!=hit.transform){
                Debug.Log(this.framecount);
                this.checking=false;
                this.framecount=0;
                gameManager.score += points; 
                Destroy(this);
            }
            
        }
    }
    

    public bool isCorrectAction(float input){
        return (input < 0 && isFlip) || (input > 0 && !isFlip) || input == 0;
    }

    int checkFrame(int frameWithInput){

        // Good!! frame llega a dar puntos
        if(frameWithInput >= CHECK_BAD_FRAMES
            && frameWithInput < CHECK_FRAMES){
            
            // EXCELLENT BEAT! frame en window de 4 frames
            if (frameWithInput  > CHECK_BAD_FRAMES + CHECK_GOOD_FRAMES
                && frameWithInput <= CHECK_BAD_FRAMES + CHECK_GOOD_FRAMES + EXCELLENT_FRAMES){
                    
                    Debug.Log("EXCELLENT");
                    return 100;
            }

            // else...
            Debug.Log("Good!");
            return 10;
        }

        //si lo haces muy pronto o te lo saltas, pierdes un punto
        Debug.Log("IDIOT");
        return -1;

    }
}
