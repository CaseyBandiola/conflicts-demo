using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOV : MonoBehaviour
{
    public float viewRadius = 2;
    public float viewAngle = 90;
    Collider2D[] playerInFov;
    public LayerMask obstacleMask, playerMask;
    public List<Transform> visiblePlayer = new List<Transform>();

    void Start()
    {
        obstacleMask = LayerMask.GetMask("Walls");
        playerMask = LayerMask.GetMask("Player");
        
    }
    void FixedUpdate()
    {
        FindVisiblePlayer();
    }

    void FindVisiblePlayer()
    {
        // looks for players in this layer
        playerInFov = Physics2D.OverlapCircleAll(transform.position, viewRadius, playerMask);

        // clear list for cases where a player was previously visible but not anymore
        // if a player is still visisble, it will be readded at the end of the for loop anyway
        visiblePlayer.Clear();
        for (int i = 0; i < playerInFov.Length; i++)
        {
            Transform player = playerInFov[i].transform;
            Vector2 dirPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

            if (Vector2.Angle(dirPlayer, transform.right) < viewAngle / 2)
            {
                float distancePlayer = Vector2.Distance(transform.position, player.position);

                if (!Physics2D.Raycast(transform.position, dirPlayer, distancePlayer, obstacleMask))
                {
                    // assume that player is already visible at this point
                    visiblePlayer.Add(player);
                }
            }
        }

        // if a player is still inside the fov, the code here will execute
        // if (visiblePlayer.Count == 1)
        // {
        //     // player visible
        //     isDetected = true;
        // }
        // else
        // {
        //     isDetected = false;
        // }
        //Debug.Log(visiblePlayer.Count);
    }
    public Vector2 DirFromAngle(float angleDeg, bool isGlobal)
    {
        // if it is not global, make it global
        if (!isGlobal)
        {
            angleDeg += transform.eulerAngles.z;
        }

        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }

    // public bool ReturnDetectionStatus(){
    //     return isDetected;
    // }
}
