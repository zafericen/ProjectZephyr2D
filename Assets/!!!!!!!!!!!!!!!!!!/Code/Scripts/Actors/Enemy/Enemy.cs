using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public class Enemy : MonoBehaviour
    {
        StateMachine stateMachine;

        void Awake()
        {
            stateMachine = new StateMachine();
        }

        void Start()
        {
            stateMachine.AddState(typeof(EnemyIdleState), new EnemyIdleState(gameObject));
            stateMachine.AddState(typeof(EnemyTeleportState), new EnemyTeleportState(gameObject));
        }

        void Update()
        {
        }
    }

}
