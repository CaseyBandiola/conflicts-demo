﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SisController : MonoBehaviour {
    private List<string> dialogue = new List<string>() {
        "Drink dialogue",
        "Did not drink dialogue",
    };
    private static Dictionary<string, int> requests = new Dictionary<string, int>() {
        { "uniform", 2500 },
    };
    private string weeklyDialogue;
    public bool didDrink;

    void Start(){
        didDrink = false;
    }

    public KeyValuePair<string, int> GetRequest1(){
        // random request every week
        KeyValuePair<string, int> weeklyRequest;
        int rqIndex = Random.Range(0, requests.Count + 1);
        if (rqIndex == requests.Count) {
            weeklyRequest = new KeyValuePair<string, int>("None", 0);
        } else {
            weeklyRequest = requests.ElementAt(rqIndex);
        }
        
        weeklyRequest = requests.ElementAt(0);

        return weeklyRequest;
    }

    public KeyValuePair<string, int> GetRequest2(){
        // random request every week
        KeyValuePair<string, int> weeklyRequest;
        // int rqIndex = Random.Range(0, requests.Count + 1);
        // if (rqIndex == requests.Count) {
        //     weeklyRequest = new KeyValuePair<string, int>("None", 0);
        // } else {
        //     weeklyRequest = requests.ElementAt(rqIndex);
        // }
        
        // if there is still a request, force it, otherwise, force none
        if( requests.Count == 1 ){
            weeklyRequest = requests.ElementAt(0);
        } else {
            weeklyRequest = new KeyValuePair<string, int>("None", 0);
        }
        

        return weeklyRequest;
    }

    public KeyValuePair<string, int> GetRequest3(){
        // random request every week
        KeyValuePair<string, int> weeklyRequest;
        
        // if there is still a request, deduct family bar and force none
        if( requests.Count == 1 ){
            // reduce family bar satisfaction
            weeklyRequest = new KeyValuePair<string, int>("None", 0);
        } else {
            weeklyRequest = new KeyValuePair<string, int>("None", 0);
        }
        

        return weeklyRequest;
    }

    public string GetDialogue(){
        // sets weekly dialogue if the Player drank or not
        //weeklyDialogue = didDrink ? dialogue[0] : dialogue[1];
        weeklyDialogue = "Pa, kailangan ko ng bagong uniform para sa school. (2 weeks)";
        return weeklyDialogue;
    }

    public string GetDialogue2(){
        // sets weekly dialogue if the Player drank or not
        //weeklyDialogue = didDrink ? dialogue[0] : dialogue[1];
        string weeklyDialogue;
        if( requests.Count > 0 ){
            weeklyDialogue = "Pa, kailangan ko ng bagong uniform para sa school. (1 week)";
        } else {
            weeklyDialogue = "Salamat po sa bagong uniform ko, Pa!";
        }
        
        return weeklyDialogue;
    }

    public string GetDialogue3(){
        // sets weekly dialogue
        // if( requests.Count > 0 ){
        //     weeklyDialogue = "Pa, kailangan ko ng bagong uniform para sa school. (1 week)";
        // } else {
        //     weeklyDialogue = "Salamat po sa bagong uniform ko, Pa!";
        // }

        weeklyDialogue = "Natatakot ako sa sitwasyon ni Antonio, pa. Sana di siya masasaktan.";
        
        return weeklyDialogue;
    }

    public static void RemoveUniformRequest(){
        requests.Remove("uniform");
    }

    public int RequestCount(){
        return requests.Count;
    }
}
