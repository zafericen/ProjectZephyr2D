using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerWeaponArtState : AttackStatesBase
    {
        public PlayerWeaponArtState(GameObject o) : base(o)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            combat.Attack(stateInputType);
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
            stateInputType = AttackInputType.WeaponArt;
        }
    }

}