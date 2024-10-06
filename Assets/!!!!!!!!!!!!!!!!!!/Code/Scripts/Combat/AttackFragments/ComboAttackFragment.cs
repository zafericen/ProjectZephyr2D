using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectZephyr
{
    public abstract class ComboAttackFragment : AttackFragment
    {
        protected ComboStreamDetector detector;
        public readonly AttackInputType activasionAttack;
        protected bool isLocked;
        protected ComboAttackFragment(GameObject attackPerformer, AnimatorOverrideController overrideController, List<AttackInputType> comboStream, AttackInputType activasionAttack) : base(attackPerformer, overrideController)
        {
            detector = new ComboStreamDetector(comboStream);
            this.activasionAttack = activasionAttack;
            isLocked = true;
        }

        public bool IsComboAccomplished(StreamList<AttackInputType> stream)
        {
            bool isAccomplished = detector.IsStreamContainsCombo(stream);

            isLocked = !isAccomplished;

            return isAccomplished;
        }

        public bool CanAttackBePerformed(StreamList<AttackInputType> stream)
        {
            if (isLocked || stream.Count <= 0)
            {
                return false;
            }

            if (stream.Get(stream.Count - 1).Equals(activasionAttack))
            {
                return true;
            }

            return false;
        }

        public override void Perform()
        {
            isLocked = true;
            base.Perform();
        }
    }
}