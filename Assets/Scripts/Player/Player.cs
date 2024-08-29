using UnityEngine;

namespace ProjectZephyr
{

    public class PlayerScript: MonoBehaviour
    {

        private StateMachine stateMachine;

        public string current;

        void Awake()
        {
            stateMachine = new StateMachine();
        }

        private void Start()
        {
            stateMachine.AddState(typeof(PlayerIdleState), new PlayerIdleState(gameObject));
            stateMachine.AddState(typeof(PlayerRunState), new PlayerRunState(gameObject));
            stateMachine.AddState(typeof(PlayerDodgeState), new PlayerDodgeState(gameObject));
            stateMachine.AddState(typeof(PlayerJumpState), new PlayerJumpState(gameObject));
            stateMachine.AddState(typeof(PlayerAttackState), new PlayerAttackState(gameObject));

            stateMachine.ChangeState(typeof(PlayerIdleState));
        }

        private void Update()
        {
            stateMachine.Run();
            Debug.Log(GetComponent<Rigidbody2D>().velocity.y);

            current = stateMachine.current.GetType().Name;
        }
    }

}