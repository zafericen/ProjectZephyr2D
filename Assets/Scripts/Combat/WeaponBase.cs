using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class WeaponBase: MonoBehaviour
    {
        public List<AttackFragment> normalAttackFragments { get; protected set; }
        public List<AttackFragment> specialAttackFragments { get; protected set; }
        public List<AttackFragment> weaponArtFragments { get; protected set; }

        public List<int> fragmentIndices { get; protected set; } = new List<int>() {0, 0, 0};

        public AttackFragment currentFragment { get; set; } = null;

        public void Attack(AttackFragment fragment)
        {
            currentFragment = fragment;
            currentFragment.Perform();
        }

        public virtual void InitializeWeapon(GameObject o)
        {
            InitializeNormalAttackFragment(o);
            InitializeSpecialAttackFragment(o);
            InitializeWeaponArtFragment(o);
        }

        public bool IsAttacking()
        {
            if(currentFragment != null) 
            {
                return !currentFragment.IsAttackFinished();
            }

            return false;
        }

        protected abstract void InitializeNormalAttackFragment(GameObject o);
        protected abstract void InitializeSpecialAttackFragment(GameObject o);
        protected abstract void InitializeWeaponArtFragment(GameObject o);

        protected abstract void DealDamage(Health health);

        private void OnTriggerEnter(Collider other)
        {
            if(!IsAttacking())
            {
                return;
            }

            Health component = other.GetComponent<Health>();
            if (component != null)
            {
                DealDamage(component);
            }
        }
    }

}