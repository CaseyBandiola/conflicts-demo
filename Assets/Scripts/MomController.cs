using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MomController : MonoBehaviour {
    private List<string> dialogue = new List<string>() {
        "Drink dialogue",
        "Did not drink dialogue",
    };
    private Dictionary<string, int> requests = new Dictionary<string, int>() { 
        { "clothes", 900}, 
        { "food", 1000 }, 
        { "water", 700 }, 
        { "school supplies", 1250 }, 
        { "electricity bill", 4000 } ,
    };
    private string weeklyDialogue;
    public bool didDrink;
    
    void Start() {
        didDrink = false;
    }

    public KeyValuePair<string, int> GetRequest(){
        // random request every week
        KeyValuePair<string, int> weeklyRequest;
        int rqIndex = Random.Range(0, requests.Count+1);
        if( rqIndex == requests.Count ){
            weeklyRequest = new KeyValuePair<string, int>("None",0);
        } else {
            weeklyRequest = requests.ElementAt(rqIndex);
        }

        return weeklyRequest;
    }

    public string GetDialogue(){
        // sets weekly dialogue if the Player drank or not
        weeklyDialogue = didDrink ? dialogue[0] : dialogue[1];
        return weeklyDialogue;
    }
}
