using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{
    private float speed;
    public int evidenceCollected;
    public Text evidenceAmt;
    public Text playerWon;
    public Text detectionStatus;
    private int maxScore = 3;
    private int lives;
    private bool hasWon;
    private bool isDetected;

    public GameObject[] cameras;
    public GameObject cam1;
    public GameObject cam2;
    // Start is called before the first frame update
    void Start(){
        lives = 3;
        speed = 10.0f;
        evidenceCollected = 0;
        hasWon = false;
        isDetected = false;
        cam1 = GameObject.Find("Camera1");
        cam2 = GameObject.Find("Camera2");
        cameras = new GameObject[2] { cam1, cam2 };
    }

    // Update is called once per frame
    void Update(){
        MovePlayer();
        // if R pressed, restart
        // if ( Input.GetKey(KeyCode.R) && hasWon ) {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }
        // if player has won, load next scene
        if (hasWon){
            playerWon.text = "All evidence collected! Press 'Enter' to proceed";
            if (Input.GetKey(KeyCode.Return)) Loader.Load(Loader.Scene.AfterMinigame1);
        }
    }

    void LateUpdate(){
        CheckDetection();
    }

    private void MovePlayer(){
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collidingObject)
    {
        // wall collision
        if (collidingObject.gameObject.tag == "Walls")
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }

        // evidence collision
        if (collidingObject.gameObject.tag == "Evidence")
        {
            // Increment score then destroy object
            addEvidence();
            Destroy(collidingObject.gameObject);
        }

        // ignore camera collision
        if (collidingObject.gameObject.tag == "Cameras")
        {
            Physics2D.IgnoreCollision(collidingObject.collider, this.gameObject.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collidingTrigger)
    {
        if (collidingTrigger.gameObject.tag == "Exit" && evidenceCollected == maxScore)
        {
            endGame(true);
        }

        // detect if in camera
        if (collidingTrigger.gameObject.tag == "FovZone")
        {
            isDetected = true;
            detectionStatus.text = "isDetected: " + isDetected;
        }
    }

    public void endGame(bool win)
    {
        setSpeed(0.0f);
        hasWon = win;
    }

    private void setSpeed(float speed)
    {
        this.speed = speed;
    }

    private void addEvidence()
    {
        evidenceCollected++;
        evidenceAmt.text = "Evidence collected: " + evidenceCollected;
    }

    private void CheckDetection()
    {
        int size = 0;
        int maxSize = 0;

        // check each camera if they see any player
        // this works because the player can only be seen by one camera at a time
        foreach (GameObject cam in cameras)
        {
            size = cam.GetComponent<FOV>().VisiblePlayerSize();
            if (size > maxSize) maxSize = size;

        }

        // if any of the cameras see a player, change the UI to know
        if (maxSize > 0)
        {
            // do detection checks here
            isDetected = true;
            detectionStatus.text = "isDetected: " + isDetected;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            isDetected = false;
            detectionStatus.text = "isDetected: " + isDetected;
        }
    }
}
