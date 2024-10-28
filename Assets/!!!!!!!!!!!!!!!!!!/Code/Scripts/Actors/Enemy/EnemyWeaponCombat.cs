using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class EnemyWeaponCombat : EnemyCombat
    {
        public WeaponBase weapon;
        private float attackCooldown = 1.0f; 
        private float lastAttackTime = 0.0f;
        private AttackFragment lastAttackFragment;

        protected EnemyBehaviour behaviour;

        private void Start()
        {
            behaviour = GetComponent<EnemyBehaviour>();
        }

        public override void Attack()
        {
            if (Time.time >= lastAttackTime + attackCooldown && IsReadyToAttack())
            {
                lastAttackFragment = weapon.normalAttackFragments.GetNext().Value;
                weapon.Attack(lastAttackFragment);
                lastAttackTime = Time.time;
            }
        }

        public override void isAttacking()
        {
            if (weapon.IsAttacking())
            {
                Debug.Log("Enemy is attacking!");
            }
        }

        private bool IsReadyToAttack()
        {
            return !weapon.IsAttacking() && !weapon.IsPerfectAttacking();
        }

        public void AfterAttack()
        {
            if (lastAttackFragment == null)
                return;

            float attackRange = lastAttackFragment.range;

            foreach (var aim in behaviour.context.aims)
            {
                if (aim != null)
                {
                    float distance = Vector3.Distance(behaviour.context.enemy.transform.position, aim.transform.position);

                    if (distance <= attackRange)
                    {
                        Vector3 directionToAim = (aim.transform.position - behaviour.context.enemy.transform.position).normalized;

                        switch (behaviour.context.direction)
                        {
                            case LookingDirection.Left:
                                if (directionToAim.x < 0)
                                {
                                    Debug.Log("Hit");
                                }
                                break;

                            case LookingDirection.Right:
                                if (directionToAim.x > 0)
                                {
                                    Debug.Log("Hit");
                                }
                                break;

                            case LookingDirection.Up:
                                if (directionToAim.y > 0 && Mathf.Abs(directionToAim.x) < 0.1f) 
                                {
                                    Debug.Log("Hit");
             
                                }
                                break;
                        }
                    }
                }
            }
        }

    }
}
