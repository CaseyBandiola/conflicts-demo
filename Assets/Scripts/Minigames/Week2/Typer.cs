using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour {
    public Text wordOutput = null;

    private string remainingWord = string.Empty;
    private string currWord = "test";

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
        if( IsCorrectLetter(letter) ){
            RemoveLetter();

            if( IsWordComplete() ){
                SetCurrentWord();
            }
        }
    }
    
    private bool IsCorrectLetter(string letter){
        // is the letter of word we're checking the first one
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter(){
        // removes first char from string
        string newString = remainingWord.Remove(0,1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete(){
        // check if remaining word still has chars in it
        return remainingWord.Length == 0;
    }
}
