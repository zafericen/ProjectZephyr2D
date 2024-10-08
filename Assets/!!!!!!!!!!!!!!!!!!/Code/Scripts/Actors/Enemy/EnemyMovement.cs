using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public enum EnemyMovementStrategy
    {
        Idle,
        Lerp,
        Teleport,
        Path,
    }

    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        private EnemyMovementStrategy strategy;
        [SerializeField]
        private float walkSpeed = 1.0f;
        [SerializeField]
        private float lerpSpeed = 1.0f;
        [SerializeField]
        private float teleportTime = 1.0f;

        [SerializeField]
        Transform lastDestination = null;

        private bool isTeleporting = false;

        [SerializeField]
        private List<Vector3> waypoints = new List<Vector3>() {};
        private int currentWaypointIndex = 0;

        private void Update()
        {
            switch (strategy)
            {
                case EnemyMovementStrategy.Lerp:
                    Lerp(lastDestination);
                    break;
                case EnemyMovementStrategy.Teleport:
                    if (!isTeleporting)
                    {
                        StartCoroutine(Teleport(lastDestination));
                    }
                    break;
                case EnemyMovementStrategy.Path:
                    Path(lastDestination);
                   break;
            }
        }

        public void Move(EnemyMovementStrategy enemyMovementStrategy, Transform destination)
        {
            strategy = enemyMovementStrategy;
            lastDestination = destination;
            isTeleporting = false; 
        }

        public bool IsMoving()
        {
            return strategy != EnemyMovementStrategy.Idle;
        }

        private IEnumerator Teleport(Transform destination)
        {
            isTeleporting = true; 

            yield return new WaitForSeconds(teleportTime); 

            transform.position = destination.position;

            strategy = EnemyMovementStrategy.Idle;
            isTeleporting = false;
        }

        private void Lerp(Transform destination)
        {
            transform.position = Vector3.Lerp(transform.position, destination.position, Time.deltaTime * lerpSpeed);

            if ((transform.position - destination.position).magnitude < 0.1f)
            {
                strategy = EnemyMovementStrategy.Idle;
            }
        }

        private void Path(Transform destination)
        {
            if (waypoints == null || waypoints.Count == 0 || currentWaypointIndex >= waypoints.Count)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination.position, Time.deltaTime * walkSpeed);
                if ((transform.position - destination.position).magnitude < 0.1f)
                {
                    strategy = EnemyMovementStrategy.Idle;
                }
                return;
            }

            Vector3 currentWaypoint = waypoints[currentWaypointIndex];

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Time.deltaTime * walkSpeed);

            if ((transform.position - currentWaypoint).magnitude < 0.1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    transform.position = Vector3.MoveTowards(transform.position, destination.position, Time.deltaTime * walkSpeed);

                    if ((transform.position - destination.position).magnitude < 0.1f)
                    {
                        strategy = EnemyMovementStrategy.Idle;
                    }
                }
            }
        }
    }
}
