using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed;
    public int evidenceCollected;
    public Text evidenceAmt;
    public Text playerWon;
    public Text detectionStatus;
    public Text livesAmt;
    private int maxScore = 3;
    private int lives;
    private bool hasLives;
    private bool hasWon;
    private bool isDetected;
    private bool lifeLost;
    

    // original player position
    private Vector3 origPos;

    public GameObject[] cameras;
    public GameObject cam1;
    public GameObject cam2;
    // Start is called before the first frame update
    void Start(){
        lives = 5;
        hasLives = true;
        speed = 10.0f;
        evidenceCollected = 0;
        hasWon = false;
        isDetected = false;
        lifeLost = false;
        origPos = gameObject.transform.position;
        cam1 = GameObject.Find("Camera1");
        cam2 = GameObject.Find("Camera2");
        cameras = new GameObject[2]{ cam1, cam2 };
    }

    // Update is called once per frame
    void Update(){
        MovePlayer();
        
        // if player has won, load pass scene
        if( hasWon ){
            playerWon.text = "All evidence collected! Press 'Enter' to proceed";
            if( Input.GetKey(KeyCode.Return) ) Loader.Load(Loader.Scene.AfterMinigame1);
        }

        // if player has no lives, load fail scene
        if( !hasLives ){
            // if player has no more lives, load next scene
            playerWon.text = "No more lives! Press 'Enter' to proceed";
            if( Input.GetKey(KeyCode.Return) ) Loader.Load(Loader.Scene.AfterMinigame1);
        }
    }

    void LateUpdate(){
        CheckDetection();
    }

    private void MovePlayer(){
        if( hasLives ){
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

    private void OnCollisionEnter2D( Collision2D collidingObject ){
        // wall collision
        if (collidingObject.gameObject.tag == "Walls")
        {
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

        // evidence collision
        if (collidingObject.gameObject.tag == "Evidence"){
            // Increment score then destroy object
            addEvidence();
            Destroy(collidingObject.gameObject);
        }

        // ignore camera collision
        if( collidingObject.gameObject.tag == "Cameras" ){
            Physics2D.IgnoreCollision(collidingObject.collider, this.gameObject.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collidingTrigger) {
        if ( collidingTrigger.gameObject.tag == "Exit" && evidenceCollected == maxScore ){
            endGame(true);
        }

        // detect if in camera
        if (collidingTrigger.gameObject.tag == "FovZone")
        {
            isDetected = true;
            detectionStatus.text = "isDetected: " + isDetected;
        }        
    }

    public void endGame(bool win){
        setSpeed(0.0f);
        hasWon = win;
    }

    private void setSpeed(float speed){
        this.speed = speed;
    }

    private void addEvidence(){
        evidenceCollected++;
        evidenceAmt.text = "Evidence: " + evidenceCollected;
    }

    private void CheckDetection(){
        int size = 0;
        int maxSize = 0;
        // check each camera if they see any player
        // this works because the player can only be seen by one camera at a time
        foreach( GameObject cam in cameras ){
            size = cam.GetComponent<FOV>().VisiblePlayerSize();
            if( size > maxSize ) maxSize = size;
            
        }

        // if any of the cameras see a player, change the UI to know
        if ( maxSize > 0 ) {
            // do detection checks here
            isDetected = true;
            detectionStatus.text = "isDetected: " + isDetected;
            
            // make sure it runs once only
            
            if( !lifeLost ){
                lifeLost = true;
                lives--;
            }
            // update lives in text
            livesAmt.text = "Lives: " + lives;
            // reset to original position
            gameObject.transform.position = origPos;
        } else {
            isDetected = false;
            detectionStatus.text = "isDetected: " + isDetected;
            lifeLost = false;

            if( lives <= 0 ){
                hasLives = false;
            }
        }
    }
}
