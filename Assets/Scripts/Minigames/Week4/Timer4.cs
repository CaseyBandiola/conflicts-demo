using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer4 : MonoBehaviour{
    public Slider timerSlider;
    public Text timerText;

    public float gameTime;
    public static float time;

    private bool stopTimer;
    void Start(){
        // max time
        gameTime = 6.0f;
        time = gameTime;

        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update(){
        ReduceTime();

        if (time > gameTime){
            time = gameTime;
        }

        timerText.text = time.ToString("0.0");
        timerSlider.value = time;

        if (time <= 0){
            stopTimer = true;
            time = 0f;
        }
    }

    public bool TimeUp(){
        return stopTimer;
    }

    public static void AddTime(){
        time += 5f;        
    }

    void ReduceTime(){
        time -= 1 * Time.deltaTime;
    }
}
