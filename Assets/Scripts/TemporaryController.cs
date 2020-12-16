using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryController : MonoBehaviour
{
	public GameObject startButton;

    public void NextScene(){
        Loader.Load(Loader.Scene.InitialSurvey);
    }
}
