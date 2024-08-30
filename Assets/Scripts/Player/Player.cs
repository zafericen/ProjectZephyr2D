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
            stateMachine.AddState(typeof(PlayerWalkState), new PlayerWalkState(gameObject));
            stateMachine.AddState(typeof(PlayerDodgeState), new PlayerDodgeState(gameObject));
            stateMachine.AddState(typeof(PlayerJumpState), new PlayerJumpState(gameObject));
            stateMachine.AddState(typeof(PlayerAttackState), new PlayerAttackState(gameObject));

            stateMachine.ChangeState(typeof(PlayerIdleState));
        }

        private void Update()
        {
            stateMachine.Run();

            current = stateMachine.current.GetType().Name;
        }
    }

}