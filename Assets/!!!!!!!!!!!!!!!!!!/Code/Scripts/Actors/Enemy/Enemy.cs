using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public class Enemy : MonoBehaviour , IDamageable
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
        
        public float health = 100f;

        public void TakeDamage(float damageMultiplier)
        {
            health -= 10f * damageMultiplier; // Adjust damage as needed
            if (health <= 0)
            {
                Destroy(gameObject); // Handle enemy death
            }
        }
    }

}
