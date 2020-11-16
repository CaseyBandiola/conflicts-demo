using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SisController : MonoBehaviour {
    private List<string> dialogue = new List<string>() {
        "Drink dialogue",
        "Did not drink dialogue",
    };
    private Dictionary<string, int> requests = new Dictionary<string, int>() {
        { "uniform", 800 },
    };
    private string weeklyDialogue;
    public bool didDrink;

    void Start(){
        didDrink = false;
    }

    public KeyValuePair<string, int> GetRequest(){
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

    public string GetDialogue(){
        // sets weekly dialogue if the Player drank or not
        //weeklyDialogue = didDrink ? dialogue[0] : dialogue[1];
        weeklyDialogue = "Pa, kailangan ko ng bagong uniform para sa school. (2 weeks)";
        return weeklyDialogue;
    }
}
