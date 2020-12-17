﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {
    // enum for scenes
    public enum Scene{
        DialogueScene1,
        TutorialMazeScene,
        AfterMinigame1,
        FamScreen,
        Week2,

    }
    public static void Load(Scene scene){
        // load a given scene
        SceneManager.LoadScene(scene.ToString());
    }
}
