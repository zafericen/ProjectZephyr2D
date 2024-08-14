using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerSpecialAttackState : PlayerAttackStateBase
    {
        public PlayerSpecialAttackState(GameObject o) : base(o)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            combat.SpecialAttack();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
        }
    }

}