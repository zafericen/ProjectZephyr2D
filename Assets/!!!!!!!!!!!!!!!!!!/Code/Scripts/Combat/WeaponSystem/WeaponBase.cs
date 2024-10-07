using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class WeaponBase: MonoBehaviour
    {
        GameObject attackPerformer;
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
        protected List<ComboAttackFragment> comboAttackFragments { get; set; }

        public List<CurcilarLinkedList<AttackFragment>> attackFragments { get; protected set; }

        public AttackFragment currentFragment { get; set; } = null;

        public void Attack(AttackFragment fragment)
        {
            currentFragment = fragment;
            currentFragment.Perform();
        }

        public virtual void InitializeWeapon(GameObject attackPerformer)
        {
            this.attackPerformer = attackPerformer;

            InitializeNormalAttackFragment(attackPerformer);
            InitializeSpecialAttackFragment(attackPerformer);
            InitializeWeaponArtFragment(attackPerformer);
            InitializeComboFragment(attackPerformer);

            attackFragments = new List<CurcilarLinkedList<AttackFragment>>
            {
                normalAttackFragments, specialAttackFragments, weaponArtFragments
            };
        }

        public bool IsAttacking()
        {

            return attackPerformer.GetComponentInChildren<PlayerAnimationEventHandler>().IsAttacking();
        }

        public bool IsPerfectAttacking()
        {
            return attackPerformer.GetComponentInChildren<PlayerAnimationEventHandler>().IsPerfectAttacking();
        }

        protected abstract void InitializeNormalAttackFragment(GameObject attackPerformer);
        protected abstract void InitializeSpecialAttackFragment(GameObject attackPerformer);
        protected abstract void InitializeWeaponArtFragment(GameObject attackPerformer);
        protected abstract void InitializeComboFragment(GameObject attackPerformer);

        //TODO: Do this in Interface
        public ComboAttackFragment CheckComboStream(StreamList<AttackInputType> stream)
        {
            foreach (var item in comboAttackFragments)
            {
                if (item.IsComboAccomplished(stream))
                {
                    return item;
                }
            }
            return null;
        }


        /// <summary>
        /// throws NULL exception if the index or the list couldnt be found. So be carefull
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
                throw new System.NullReferenceException("Non acceptable input in weapon. Animator Override List is null or it has not enough inputs");            
            }

            return animators[index];
        }
    }



}