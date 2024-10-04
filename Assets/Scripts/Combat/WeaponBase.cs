using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class WeaponBase: MonoBehaviour
    {
        public CurcilarLinkedList<AttackFragment> normalAttackFragments { get; protected set; }
        public CurcilarLinkedList<AttackFragment> specialAttackFragments { get; protected set; }
        public CurcilarLinkedList<AttackFragment> weaponArtFragments { get; protected set; }
        
        public List<CurcilarLinkedList<AttackFragment>> attackFragments { get; protected set; }

        public AttackFragment currentFragment { get; set; } = null;

        public void Attack(AttackFragment fragment)
        {
            currentFragment = fragment;
            currentFragment.Perform();
        }

        public virtual void InitializeWeapon(GameObject attackPerformer)
        {
            InitializeNormalAttackFragment(attackPerformer);
            InitializeSpecialAttackFragment(attackPerformer);
            InitializeWeaponArtFragment(attackPerformer);

            attackFragments = new List<CurcilarLinkedList<AttackFragment>>
            {
                normalAttackFragments, specialAttackFragments, weaponArtFragments
            };
        }

        public bool IsAttacking()
        {
            if(currentFragment != null) 
            {
                return !currentFragment.IsAttackFinished();
            }

            return false;
        }

        protected abstract void InitializeNormalAttackFragment(GameObject attackPerformer);
        protected abstract void InitializeSpecialAttackFragment(GameObject attackPerformer);
        protected abstract void InitializeWeaponArtFragment(GameObject attackPerformer);
    }



}