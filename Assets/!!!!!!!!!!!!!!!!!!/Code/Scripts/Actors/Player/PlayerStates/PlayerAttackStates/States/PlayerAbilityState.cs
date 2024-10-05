using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectZephyr
{
    public partial class PlayerAbilityState : AttackStatesBase
    {
        Ability ability;
        public PlayerAbilityState(GameObject o) : base(o)
        {
            ability = o.GetComponent<Ability>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            ability.AbilityAttack();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        protected override void SetStateInput()
        {
            stateInputType = AttackInputType.Ability;
        }

    }
}
