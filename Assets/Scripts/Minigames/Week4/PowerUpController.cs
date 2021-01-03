using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour{
    public float speed;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.x > -13 ){
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}
