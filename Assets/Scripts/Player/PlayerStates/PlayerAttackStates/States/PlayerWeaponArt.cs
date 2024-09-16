using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerWeaponArtState : AttackStatesBase
    {

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            combat.Attack(AttackType.WEAPON_ART);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit(MachineContext context)
        {
            base.OnExit(context);
        }

        protected override void SetStateInput()
        {
            stateInputType = AttackInputType.WeaponArt;
        }
    }

}