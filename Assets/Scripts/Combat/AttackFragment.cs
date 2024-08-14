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

        public float damageMultiplier = 0.70f;

        public AttackFragment(GameObject o, string AnimatorPath) 
        {
            attackPerformer = o;
            animator = o.GetComponentInChildren<Animator>();
            LoadAnimator(AnimatorPath);
        }

        public void Perform()
        {
            OverrideAnimator();            
            ApplyLogic();
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