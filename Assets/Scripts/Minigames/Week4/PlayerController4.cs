using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController4 : MonoBehaviour{
    private float speed;

    public Timer4 timer;
    public bool timeUp;
    private bool gameEnd;

    public Text gameOver;
    // Start is called before the first frame update
    void Start(){
        speed = 1.8f;
        timeUp = false;
        gameEnd = false;
    }

    // Update is called once per frame
    void Update() {
        MovePlayer();
        // fail conditions
        if( timer.TimeUp() && !gameEnd ){
            // stop movement
            if( timeUp == false ){
                timeUp = true;
            }

            // FAIL CODE
            gameOver.text = "Fail! Press 'Enter' to proceed";
            // load fail scene
            if (Input.GetKey(KeyCode.Return)){
                Loader.Load(Loader.Scene.Week2);
            }

        }
    }

    private void MovePlayer(){
        if( !timeUp ){
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

        if( collidingObject.gameObject.tag == "Exit" ){
            // end game
            gameEnd = true;
            // stop movement
            if (timeUp == false){
                timeUp = true;
            }

            // success code
            gameOver.text = "Success! Press 'Enter' to proceed";

            // Load success scene
            if (Input.GetKey(KeyCode.Return)){
                Loader.Load(Loader.Scene.Week2);
            }
        }
    }

    public void AddSpeed(float s){
        speed += s;
    }
}
