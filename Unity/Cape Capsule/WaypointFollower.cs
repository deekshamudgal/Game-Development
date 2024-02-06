using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Named it Waypoint rather than Platform follower to be reusable for enemies in the future code 

public class WaypointFollower : MonoBehaviour
{
    //QUESTION OF THE DAY: HOW DO YOU KNOW WHAT KIND OF GAME OBJECT TO SELECT FROM WHEN YOU ARE BUILDING YOUR VAR??
    //we made an array instead of a simple variable, so that we can store all the waypoints at one place, SIMPLICITY IS THE BEST :))
    [SerializeField] GameObject[] waypoints;
    [SerializeField] float speed = 1f;
    int currentWaypointIndex = 0;


    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length ) 
            {
            currentWaypointIndex = 0;
            }
        }
        //{HELP:Instead of using physics like we did in the player movement we are using transform and not even using a rigid body component. Why?}
        //What is the Time.deltaTime? And how come it changes with the frame rate at which the game is played at? And if it does all of this, why does it matter?
        //I still don't get why are we multiplying speed with Time.deltaTime? What could I achieve by mutliplying the time interval from start to current frame.
        //What is even a frame. I am confusion :((
        transform.position= Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
