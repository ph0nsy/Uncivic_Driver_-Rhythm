using System;
using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {   
        if(carsPerSong.Count > 0){
            if(fpsCounter == 0){
                if(carsPerSong[0].Item1 == "cop") Instantiate(car, new Vector3(-5f,-5f,50f), new Quaternion(120f,180f,-7f,1f));
                else Instantiate(cop, new Vector3(-5f,-5f,50f), new Quaternion(120f,180f,-7f,1f));
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
