using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MomController : MonoBehaviour {
    private List<string> dialogue = new List<string>() {
        "Susunod, umuwi ka nang mas maaga o sabihan mo muna ako pag late ka uuwi. Huwag mo kalimutan mga pangangailangan natin sa bahay.",
        "Kamusta naman trabaho mo? Huwag mo kalimutan mga pangangailangan natin sa bahay.",
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
        // checks if player drank
        string drink = DialogueController.choicesMade[2];
        // string drink = "test";
        if (drink.Equals("Go drinking (Lower Family, Increase Boss)")) {
            didDrink = true;
        } else {
            didDrink = false;
        }
        // sets weekly dialogue if the Player drank or not
        weeklyDialogue = didDrink ? dialogue[0] : dialogue[1];
        return weeklyDialogue;
    }
}
