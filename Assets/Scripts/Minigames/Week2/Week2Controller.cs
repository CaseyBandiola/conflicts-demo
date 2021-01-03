using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Week2Controller : MonoBehaviour {
    public WordBank wordBank;
    public Timer timer;
    public Typer typer;
    public Text endGame;
    public Text word;

    public bool timeUp;
    public static bool didPass;
    void Start()
    {
        timeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( timer.TimeUp() || (wordBank.WordsLeft() - 1 < -1 ) ){
            // end game

            if( timer.TimeUp() || wordBank.WordsLeft() == 0 ){
                word.gameObject.SetActive(false);
                endGame.gameObject.SetActive(true);
            }
            // This if check is here so typer is only toggled once
            if( timeUp == false ){
                timeUp = true;
                typer.TimeUp();
            }
            
            

            if( typer.GetScore() >= 4 ){
                // load dialogue scene for PASS
                if( Input.GetKey(KeyCode.Return) ){
                    didPass = true;
                    Loader.Load(Loader.Scene.Week2);
                    
                } 
            } else {
                // load dialogue scene for FAIL
                if( Input.GetKey(KeyCode.Return) ){
                    didPass = false;
                    Loader.Load(Loader.Scene.Week2);
                } 
            }
            
        }
    }
}
