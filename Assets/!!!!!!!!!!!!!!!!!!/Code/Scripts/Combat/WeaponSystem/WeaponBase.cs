using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class WeaponBase: MonoBehaviour
    {
        protected enum Attacks
        {
            NA,
            SA,
            WA,
            Combo
        }
        [SerializeField] private List<AnimatorOverrideController> animatorOverrideControllersNA;
        [SerializeField] private List<AnimatorOverrideController> animatorOverrideControllersSA;
        [SerializeField] private List<AnimatorOverrideController> animatorOverrideControllersWA;
        [SerializeField] private List<AnimatorOverrideController> animatorOverrideControllersComboAttacks;

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


        /// <summary>
        /// returns NULL if the index or the list couldnt be found. So be carefull
        /// </summary>
        /// <param name="attackOverrideList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected AnimatorOverrideController GetOverrideFromList(Attacks attackOverrideList, int index)
        {
            List<AnimatorOverrideController> animators;

            switch (attackOverrideList)
            {
                case Attacks.NA: animators = animatorOverrideControllersNA; break;
                case Attacks.SA: animators = animatorOverrideControllersSA; break;
                case Attacks.WA: animators = animatorOverrideControllersWA; break;
                case Attacks.Combo: animators = animatorOverrideControllersComboAttacks; break;
                default: animators= null; break;
            }

            if(animators == null || index <0 || index >= animators.Count)
            {
                Debug.LogError("Non acceptable input in weapon");
                return null; 
            }

            return animators[index];
        }
    }



}