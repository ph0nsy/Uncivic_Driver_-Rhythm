using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCheck : MonoBehaviour
{

    // Active frame constants
    int CHECK_FRAMES = 15;
    int GOOD_FRAMES = 10;
    int EXCELLENT_FRAMES = 4;
    int CHECK_BAD_FRAMES;
    int CHECK_GOOD_FRAMES;


    int framecount;
    bool checking = false;
    bool isFlip = false;
    int points;


    // Start is called before the first frame update
    void Start()
    {  
        this.CHECK_BAD_FRAMES = CHECK_FRAMES-GOOD_FRAMES;
        this.CHECK_GOOD_FRAMES = (GOOD_FRAMES-EXCELLENT_FRAMES)/2;
        this.framecount=0;
        this.checking=false;
        this.points=0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //0 es nada, 1 es dcha y -1 izq
        float input = Input.GetAxis("Horizontal");

        if(this.checking){

            if(input!=0 && isCorrectAction(input)){
                this.points = checkFrame(framecount);
            }
            if(framecount >= CHECK_FRAMES){
                this.checking=false;
                this.points=-1;
            }
            ++framecount;
        }
    }

    
    bool isCorrectAction(float input){
        return (input < 0 && isFlip) || (input > 0 && !isFlip) || input == 0;
    }

    int checkFrame(int frameWithInput){

        // Good!! frame llega a dar puntos
        if(frameWithInput >= CHECK_BAD_FRAMES
            && frameWithInput < CHECK_FRAMES){
            
            // EXCELLENT BEAT! frame en window de 4 frames
            if (frameWithInput  > CHECK_BAD_FRAMES + CHECK_GOOD_FRAMES
                && frameWithInput <= CHECK_BAD_FRAMES + CHECK_GOOD_FRAMES + EXCELLENT_FRAMES){
                    return 100;
            }

            // else...
            return 10;
        }

        //si lo haces muy pronto o te lo saltas, pierdes un punto
        return -1;

    }
}
