using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public class EnemyLerp : EnemyMovement
    {

        [SerializeField]
        private float lerpSpeed = 1.0f;

        public override void Move(Transform destination)
        {
            transform.position = Vector3.Lerp(transform.position, destination.position, Time.deltaTime * lerpSpeed);
        }

    }

}
