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
            stateMachine.AddState(nameof(PlayerIdleState), new PlayerIdleState(gameObject));
            stateMachine.AddState(nameof(PlayerRunState), new PlayerRunState(gameObject));
            stateMachine.AddState(nameof(PlayerDodgeState), new PlayerDodgeState(gameObject));
            stateMachine.AddState(nameof(PlayerNormalAttackState), new PlayerNormalAttackState(gameObject));
            stateMachine.AddState(nameof(PlayerSpecialAttackState), new PlayerSpecialAttackState(gameObject));
            stateMachine.AddState(nameof(PlayerWeaponArtState), new PlayerWeaponArtState(gameObject));

            stateMachine.ChangeState(nameof(PlayerIdleState));
        }

        private void Update()
        {
            stateMachine.Run();
            current = stateMachine.current.GetType().Name;
        }
    }

}