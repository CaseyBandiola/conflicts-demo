using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MomController : MonoBehaviour {
    private List<string> dialogue = new List<string>() {
        "Susunod, umuwi ka nang mas maaga o sabihan mo muna ako pag late ka uuwi. Huwag mo kalimutan mga pangangailangan natin sa bahay.",
        "Kamusta naman trabaho mo? Huwag mo kalimutan mga pangangailangan natin sa bahay.",
    };
    private static Dictionary<string, int> requests = new Dictionary<string, int>() { 
        // { "clothes", 900}, 
        // { "food", 1000 }, 
        // { "water", 700 }, 
        // { "school supplies", 1250 }, 
        // { "electricity bill", 4000 } ,
        { "groceries", 3000 },
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

    public KeyValuePair<string, int> GetRequest2(){
        // random request every week
        KeyValuePair<string, int> weeklyRequest;
        // int rqIndex = Random.Range(0, requests.Count+1);
        // if( rqIndex == requests.Count ){
        //     weeklyRequest = new KeyValuePair<string, int>("None",0);
        // } else {
        //     weeklyRequest = requests.ElementAt(rqIndex);
        // }
        weeklyRequest = requests.ElementAt(0);

        return weeklyRequest;
    }

    public KeyValuePair<string, int> GetRequest3(){
        // random request every week
        KeyValuePair<string, int> weeklyRequest;
        // int rqIndex = Random.Range(0, requests.Count+1);
        // if( rqIndex == requests.Count ){
        //     weeklyRequest = new KeyValuePair<string, int>("None",0);
        // } else {
        //     weeklyRequest = requests.ElementAt(rqIndex);
        // }

        // if there is still groceries, deduct family bar, either way, have the lawyer request pop up
        if( requests.Count == 1 ){
            // reduce the family bar satisfaction
            FamProgressBar.ChangeFill(-30);
            requests.Remove("groceries");
            requests.Add("Lawyer", 5000);
            weeklyRequest = requests.ElementAt(0);
        } else {
            requests.Add("Lawyer", 5000);
            weeklyRequest = requests.ElementAt(0);
        }
        

        return weeklyRequest;
    }

    public string GetDialogue(){
        // checks if player drank
        string drink = "test";//DialogueController.choicesMade[2];
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

    public string GetDialogue2(){
        // sets weekly dialogue if the Player drank or not
        //weeklyDialogue = didDrink ? dialogue[0] : dialogue[1];
        weeklyDialogue = "Kailangan ko nang pumunta sa palengke at grocery para sa bahay. (P3,000 - due now)";
        return weeklyDialogue;
    }

    public string GetDialogue3(){
        // sets weekly dialogue
        // if groceries were paid, start of dialogue is different
        if( requests.Count == 1 ){
            weeklyDialogue += "Wala na tayong makain, Albert. Walang pera para mamalengke at pumunta ng grocery.";
        } else {
            weeklyDialogue += "Nakabili na ako ng kakainin natin. Salamat Albert.";
        }

        weeklyDialogue += " Mag-ipon na na rin tayo para sa pam-piyansa at abogado ni Antonio.";
        return weeklyDialogue;
    }

    public static void RemoveGroceryRequest(){
        requests.Remove("groceries");
    }

    public static void RemoveLawyerRequest(){
        requests.Remove("Lawyer");
    }

    public int RequestCount(){
        return requests.Count;
    }
}
