using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectZephyr
{
    public abstract class ComboAttackFragment : AttackFragment
    {
        protected ComboStreamDetector detector;
        protected bool isLocked;
        protected ComboAttackFragment(GameObject attackPerformer, AnimatorOverrideController overrideController, List<AttackInputType> comboStream) : base(attackPerformer, overrideController)
        {
            detector = new ComboStreamDetector(comboStream);
            isLocked = true;
        }

        public bool IsComboAccomplished(StreamList<AttackInputType> stream)
        {
            bool isAccomplished = detector.IsStreamContainsCombo(stream);

            isLocked = !isAccomplished;

            return isAccomplished;
        }


        public override void Perform()
        {
            isLocked = true;
            base.Perform();
        }
    }
}