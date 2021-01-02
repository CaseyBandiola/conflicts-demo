using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {
    // enum for scenes
    public enum Scene{
        DialogueScene1,
        DialogueScene2,
        DialogueScene3,
        TutorialMazeScene,
        AfterMinigame1Pass,
        AfterMinigame1Fail,
        AfterMinigame2Pass,
        AfterMinigame2Fail,
        AfterMinigame3,
        FamScreen,
        InitialSurvey,

    }
    public static void Load(Scene scene){
        // load a given scene
        SceneManager.LoadScene(scene.ToString());
    }
}
