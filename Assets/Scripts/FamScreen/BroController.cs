using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BroController : MonoBehaviour
{
    private List<string> dialogue = new List<string>() {
        "Drink dialogue",
        "Did not drink dialogue",
    };
    private Dictionary<string, int> requests = new Dictionary<string, int>() {
        // { "art materials", 300},
        // { "uniform", 800 },
        // { "shoe repair", 250 },
    };
    private string weeklyDialogue;
    public bool didDrink;

    void Start() {
        didDrink = false;
    }

    public KeyValuePair<string, int> GetRequest() {
        // random request every week
        KeyValuePair<string, int> weeklyRequest;
        int rqIndex = Random.Range(0, requests.Count + 1);
        if (rqIndex == requests.Count) {
            weeklyRequest = new KeyValuePair<string, int>("None", 0);
        } else {
            weeklyRequest = requests.ElementAt(rqIndex);
        }

        return weeklyRequest;
    }

    public string GetDialogue() {
        // sets weekly dialogue if the Player drank or not
        // weeklyDialogue = didDrink ? dialogue[0] : dialogue[1];
        weeklyDialogue = "May mga isyu sa school pero ok lang ako.";
        return weeklyDialogue;
    }

    public string GetDialogue2() {
        // sets weekly dialogue if the Player drank or not
        // weeklyDialogue = didDrink ? dialogue[0] : dialogue[1];
        weeklyDialogue = "Narinig ko sa aking mga guro na kakasuhan daw ng gobyerno ang mga nagrarally.";
        return weeklyDialogue;
    }
}
