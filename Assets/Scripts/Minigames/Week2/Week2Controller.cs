using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Week2Controller : MonoBehaviour {
    public WordBank wordBank;
    public Timer timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( timer.TimeUp() || wordBank.WordsLeft() == 0 ){
            // end game
            //Debug.Log("game end");
            if( Input.GetKey(KeyCode.Return) ) Loader.Load(Loader.Scene.Week2);
        }
    }
}
