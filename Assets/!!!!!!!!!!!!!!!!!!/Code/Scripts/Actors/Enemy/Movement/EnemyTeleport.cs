using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr 
{

    public class EnemyTeleport : EnemyMovement
    {
        [SerializeField]
        private float teleportTime = 1.0f;

        public bool isTeleporting { get; internal set; }

        private Coroutine teleportCoroutine;

        public override void Move(Transform destination)
        {
            if (!isTeleporting)
            {
                teleportCoroutine = StartCoroutine(Teleport(destination));
            }
        }

        private IEnumerator Teleport(Transform destination)
        {
            isTeleporting = true;

            yield return new WaitForSeconds(teleportTime);

            transform.position = destination.position;

            isTeleporting = false;
        }

        public void CancelTeleport()
        {
            if (isTeleporting && teleportCoroutine != null)
            {
                StopCoroutine(teleportCoroutine);
                isTeleporting = false;
            }
        }
    }

}
