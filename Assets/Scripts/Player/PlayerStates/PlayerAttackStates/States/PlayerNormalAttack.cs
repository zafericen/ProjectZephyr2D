using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerNormalAttackState : AttackStatesBase
    {
        public PlayerNormalAttackState(GameObject o) : base(o)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            combat.NormalAttack();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        protected override void SetStateInput()
        {
            stateInputType = AttackInputType.Normal;
        }
    }
}