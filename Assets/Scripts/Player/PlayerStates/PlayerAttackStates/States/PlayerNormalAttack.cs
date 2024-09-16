using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerNormalAttackState : AttackStatesBase
    {

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            combat.Attack(AttackType.NORMAL_ATTACK);
        }

        protected override void SetStateInput()
        {
            stateInputType = AttackInputType.Normal;
        }
    }
}