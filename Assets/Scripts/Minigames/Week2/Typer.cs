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
        CheckInput();
    }

    // Sets the current word in the screen
    private void SetCurrentWord(){
        // Get word from word bank
        // Update remaining word
        SetRemainingWord(currWord);
    }

    // Updates remaining word tracked by Typer
    private SetRemainingWord(string s){
        // update remaining word
        remainingWord = s;
        wordOutput.text = remainingWord;
    }

    private void CheckInput(){
        if( Input.anyKeyDown ){
            // tracks keys pressed this frame
            string keysPressed = Input.inputString;

            // ensures that only one letter is read per frame, if ever 2 keys are pressed at the exact same frame
            if( keysPressed.Length == 1 ){
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string letter){

    }
    
    private bool IsCorrectLetter(string letter){
        return false;
    }

    private void RemoveLetter(){

    }

    private bool IsWordComplete(){
        return false;
    }
}
