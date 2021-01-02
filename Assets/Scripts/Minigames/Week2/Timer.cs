using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Slider timerSlider;
    public Text timerText;
    
    public float gameTime;
    public static float time;

    private bool stopTimer;

    void Start() {
        // how much time there is in the game
        gameTime = 10.0f;
        time = gameTime;

        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;    
    }

    void Update() {
        ReduceTime();
        
        // old text formatting
        // int minutes = Mathf.FloorToInt(time / 60);
        // int seconds = Mathf.FloorToInt(time-minutes * 60f);        
        // string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = time.ToString("0.0");
        timerSlider.value = time;

        if( time <= 0 ){
            stopTimer = true;
            time = 0f;
        }

        if( !stopTimer ){
            
        }
    }

    public bool TimeUp(){
        return stopTimer;
    }

    public static void AddTime(){
        time += 0.75f;
    }

    void ReduceTime(){
        time -= 1 * Time.deltaTime;
    }
}
