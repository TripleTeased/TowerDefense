using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region Properties

    public EnemyScriptableObject enemy;

    public Vector2[] waypoints;

    private int waypointIndex = 0;

    #endregion

    #region Constructor

    private void Update()
    {
        WalkDownPath();
    }

    public void SetupEnemy(Vector2[] _wayPoints)
    {
        waypoints = _wayPoints;
        transform.position = HelperFunctions.GetScreenLocationBasedOnArrayPosition(waypoints[waypointIndex]);
    }

    #endregion

    #region Functions

    public void WalkDownPath()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               HelperFunctions.GetScreenLocationBasedOnArrayPosition(waypoints[waypointIndex]),
               2f * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == (Vector3)HelperFunctions.GetScreenLocationBasedOnArrayPosition(waypoints[waypointIndex]))
            {
                waypointIndex += 1;
            }
        }
    }

    #endregion

}
