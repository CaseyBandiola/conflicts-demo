using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        MovePlayer();
    }

    private void MovePlayer(){
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collidingObject){
        // wall collision
        if (collidingObject.gameObject.tag == "Walls"){
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
