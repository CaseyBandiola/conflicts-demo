using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour {
    public Text wordOutput = null;

    private string remainingWord = string.Empty;
    private string currWord = "Test";

    private void Start() {
        SetCurrentWord();
    }

    private void Update() {
        
    }

    // Sets the current word in the screen
    private void SetCurrentWord(){
        // Get word from word bank
        // Update remaining word
        SetRemainingWord(currWord);
    }

    private SetRemainingWord(string s){

    }
}
