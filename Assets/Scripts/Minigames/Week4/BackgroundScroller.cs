using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    public BoxCollider2D collider;
    public Rigidbody2D rb;

    private float width;
    public float scrollSpeed = -2f;
    // Start is called before the first frame update
    void Start() {
        // get components from object
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        
        // disable collider after to prevent memory waste
        width = collider.size.x;
        collider.enabled = false;

        // scroll to the left
        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.position.x < -width ){
            Vector2 resetPos = new Vector2(width*2f, 0);
            transform.position = (Vector2) transform.position + resetPos;
        }
    }
}
