using System.Collections;
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

    }

    private void Shuffle(List<string> list){

    }

    private void ConvertToLower(List<string> list){

    }

    public string GetWord(){
        return "";
    }
}
