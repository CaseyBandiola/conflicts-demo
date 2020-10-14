using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryController : MonoBehaviour
{
    public void NextScene(){
        Loader.Load(Loader.Scene.FamScreen);
    }
}
