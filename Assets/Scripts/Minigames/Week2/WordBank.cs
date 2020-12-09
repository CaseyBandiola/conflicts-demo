using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    private List<string> originalWords = new List<string>()
    {
        "kommunista", "target", "rebelde", "nanlaban", "adik", "instigator", "nationalista", "oligarkiya",
    };

    private List<string> workingWords = new List<string>();

    private void Awake(){
        // copies original words into working words list
        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
        ConvertToLower(workingWords);        
    }
    
    // randomize words in list
    private void Shuffle(List<string> list){
        for( int i = 0; i < list.Count; i++ ){        
            int random = Random.Range(i, list.Count);
            
            string temp = list[i];

            // swap current word with random word
            list[i] = list[random];
            list[random] = temp;
        }
    }

    // converts all words in string to lowercase
    private void ConvertToLower(List<string> list){
        for( int i = 0; i < list.Count; i++ ){
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord(){
        string newWord = string.Empty;

        // as long as we have working words
        if( workingWords.Count != 0 ){
            // get last word in the list
            newWord = workingWords.Last();
            // remove word from working words
            workingWords.Remove(newWord);
        }
        
        return newWord;
    }
}
