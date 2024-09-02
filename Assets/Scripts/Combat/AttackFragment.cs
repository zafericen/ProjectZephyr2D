using System;
using UnityEditor;
using UnityEngine;

namespace ProjectZephyr
{
    public abstract class AttackFragment
    {
        protected GameObject attackPerformer;
        protected Animator animator;
        protected const string animationName = "Attack";
        public AnimatorOverrideController animatorOverride;

        public float damageMultiplier = 1f;

        public AttackFragment(GameObject attackPerformer, string AnimatorPath) 
        {
            this.attackPerformer = attackPerformer;
            animator = attackPerformer.GetComponentInChildren<Animator>();
            LoadAnimator(AnimatorPath);
        }

        public void Perform()
        {
            OverrideAnimator();
            PlayAnimator();
            ApplyLogic();
        }

        protected virtual void PlayAnimator()
        {
            animator.Play(animationName, 0, 0);

        }

        public void OverrideAnimator()
        {
            animator.runtimeAnimatorController = animatorOverride;
        }

        public bool IsAttackFinished()
        {
            return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f && animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
        }

        public void LoadAnimator(string path)
        {
            animatorOverride = AssetDatabase.LoadAssetAtPath<AnimatorOverrideController>(path);
        }

        public float FragmentTime()
        {
            return animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        }

        public abstract void ApplyLogic();

    }
}