using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject car;
    public GameObject cop;
    public TextAsset textFile;
    string textContent;
    List<Tuple<string, int>> carsPerSong;
    int fpsCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        textContent = textFile.text;  //this is the content as string
        carsPerSong = new List<Tuple<string, int>>();
        textToMap(textContent);

    }

    void OnEnable(){
        carsPerSong = new List<Tuple<string, int>>();
        textToMap(textContent);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(carsPerSong.Any()){
            if(fpsCounter == 0){
                if(carsPerSong[0].Item1 == "cop") Instantiate(cop, this.transform);
                else Instantiate(car, this.transform);
                fpsCounter++;
            } else if (fpsCounter == carsPerSong[0].Item2){
                carsPerSong.RemoveAt(0);
                fpsCounter = 0;
            } else fpsCounter++;
        }
    }

    void textToMap(string text){
        char[] separators = { ',', '\n' };
        string[] songSeed = text.Split(separators);
        int iter = 0;
        string current = songSeed[iter];
        while(current != "-"){
            Debug.Log(songSeed[iter] + " " + songSeed[iter+1]);
            carsPerSong.Add(new Tuple<string, int>(current, Int32.Parse(songSeed[iter+1])));
            iter+=2;
            current = songSeed[iter];
        }
    }
}
