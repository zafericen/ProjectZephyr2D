using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerSpecialAttackState : AttackStatesBase
    {
        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            combat.Attack(AttackType.SPECIAL_ATTACK);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit(MachineContext context)
        {
        }

        protected override void SetStateInput()
        {
            stateInputType = AttackInputType.Special;
        }
    }

}