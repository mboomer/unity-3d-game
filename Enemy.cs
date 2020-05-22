using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
                                                                // [SerializeField] make variable available to the UI transform component    
    [SerializeField] private Transform[] wayPoints;             // create array to store the waypoints the enemy will follow
    [SerializeField] [Range(0, 1f)] private float enemySpeed;   // 0 to 1 - is a float so can have every value inbetween 0 -> 1 

    // make enemySpeed available to UI transform component
    private int wayPointIndex;                                  // default for int is zero
    private Vector3 targetPosition;                             // the position of the next point to move to

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = wayPoints[0].position;                 // sets the start position that the enemy wants to move towards
    }

    // Update is called once per frame
    void Update()
    {
        // each frame move the enemy position closer to the starting target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.5f * enemySpeed);
        
        // check to see if you are within a certain distance of the targetPosition
        if (Vector3.Distance(transform.position, targetPosition) < 0.25f) {

            if (wayPointIndex >= wayPoints.Length - 1) 
            {    // size in UI is displayed as 1 more than the array length
                wayPointIndex = 0;                          // if we are at last waypoint go back to start
            } 
            else 
            {
                wayPointIndex++;                            // if not at last waypoint go on to next one
            }
        targetPosition = wayPoints[wayPointIndex].position; // get the position of the next waypoint to move towards
        }
    }
}
