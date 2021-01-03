using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start(){
        speed = 1.8f;
    }

    // Update is called once per frame
    void Update() {
        //float horizontal = Input.GetAxis("Horizontal");
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

        // powerup collision
        if ( collidingObject.gameObject.tag == "Evidence" && collidingObject.gameObject.name == "Bike" ){
            // Increment score then destroy object
            AddSpeed(2.45f);
            Destroy(collidingObject.gameObject);
        }

        if (collidingObject.gameObject.tag == "Evidence" && collidingObject.gameObject.name == "Watch"){
            // Increment score then destroy object
            Timer4.AddTime();
            Destroy(collidingObject.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collidingTrigger){
        if (collidingTrigger.gameObject.tag == "Exit"){
            // end game
        }
    }

    public void AddSpeed(float s){
        speed += s;
    }
}
