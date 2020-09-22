using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed;
    public int evidenceCollected;
    public Text evidenceAmt;
    // Start is called before the first frame update
    void Start(){
        speed = 10.0f;
        evidenceCollected = 0;
    }

    // Update is called once per frame
    void Update(){
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
    }

    private void addEvidence(){
        evidenceCollected++;
        evidenceAmt.text = "Evidence collected: " + evidenceCollected;
    }
}
