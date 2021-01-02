using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Week2Controller : MonoBehaviour {
    public WordBank wordBank;
    public Timer timer;
    public Typer typer;

    public bool timeUp;
    void Start()
    {
        timeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( timer.TimeUp() || wordBank.WordsLeft()-1 == -1 ){
            // end game
            // This if check is here so typer is only toggled once
            if( timeUp == false ){
                timeUp = true;
                typer.TimeUp();
            }
            
            if( Input.GetKey(KeyCode.Return) ) Loader.Load(Loader.Scene.Week2);
        }
    }
}
