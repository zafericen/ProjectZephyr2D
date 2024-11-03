using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class EnemyMovement : Movement, IEnemyAction
    {
        [SerializeField]
        private float lastTime = 0.0f;
        [SerializeField]
        private float timeMultiplier = 1.0f;
        [SerializeField]
        private float score = 0.0f;
        [SerializeField]
        private float scoreMultiplier = 10.0f;

        float IEnemyAction.lastTime =>lastTime;

        float IEnemyAction.timeMultiplier => timeMultiplier;

        float IEnemyAction.score => score;

        float IEnemyAction.scoreMultiplier => scoreMultiplier;

        Enemy enemy;

        [SerializeField]
        private float distanceMultiplier = 1.0f;

        [SerializeField]
        private float neededDistance = 3.0f;

        void IEnemyAction.Score()
        {
            Vector2 dir = enemy.Player.transform.position - transform.position;
            score = Mathf.Abs(dir.magnitude) * scoreMultiplier;
        }

        void Awake()
        {
            enemy = GetComponent<Enemy>();
            rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            lastTime = Time.time;
        }

        void Update()
        {
            Vector2 dir = enemy.Player.transform.position - transform.position;
            dir.y = 0;
            Move(dir.normalized);

            if(Mathf.Abs(dir.magnitude) < neededDistance)
            {
                status = Status.SUCCESS;
            }
        }

        public override bool Check(Context context)
        {
            return ((IEnemyAction)this).Roll();
        }

        void OnEnter()
        {
            lastTime = Time.time;
            status = Status.WORKING;
        }

    }
}
