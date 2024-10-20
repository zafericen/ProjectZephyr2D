using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public class EnemyPath : EnemyMovement
    {
        [SerializeField]
        private float walkSpeed = 1.0f;

        [SerializeField]
        private List<Vector3> waypoints = new List<Vector3>() { };

        private int currentWaypointIndex = 0;

        public override void Move(Transform destination)
        {
            if (currentWaypointIndex >= waypoints.Count)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination.position, Time.deltaTime * walkSpeed);
                return;
            }

            Vector3 currentWaypoint = waypoints[currentWaypointIndex];

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Time.deltaTime * walkSpeed);
        }

        public void ResetPath()
        {
            currentWaypointIndex = 0;
        }

    }

}

