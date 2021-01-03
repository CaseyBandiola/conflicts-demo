using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour{
    private float speed;
    // Start is called before the first frame update
    void Start(){
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.x > -13 ){
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}
