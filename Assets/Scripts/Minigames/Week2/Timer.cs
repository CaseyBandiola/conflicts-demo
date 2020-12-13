using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Slider timerSlider;
    public Text timerText;
    
    public float gameTime;
    public float time;

    private bool stopTimer;

    void Start() {
        // how much time there is in the game
        gameTime = 10.0f;

        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;    
    }

    void Update() {
        time = gameTime - Time.time;
        
        // old text formatting
        // int minutes = Mathf.FloorToInt(time / 60);
        // int seconds = Mathf.FloorToInt(time-minutes * 60f);        
        // string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if( time <= 0 ){
            stopTimer = true;
            time = 0f;
        }

        if( !stopTimer ){
            timerText.text = time.ToString("0.0");
            timerSlider.value = time;
        }
    }

    public bool TimeUp(){
        return stopTimer;
    }

    public void AddTime(){
        time += 0.5f;
    }
}
