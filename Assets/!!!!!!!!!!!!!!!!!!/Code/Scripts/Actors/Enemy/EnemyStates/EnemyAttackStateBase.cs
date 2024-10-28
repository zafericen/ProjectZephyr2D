using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public abstract class EnemyAttackStateBase : EnemyStateBase
    {
        protected EnemyWeaponCombat combat;
        protected bool isPerfectAttack;

        protected EnemyAttackStateBase(GameObject o) : base(o)
        {
            combat = o.GetComponent<EnemyWeaponCombat>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (!combat.weapon.IsAttacking())
            {
                busy = false;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }

}