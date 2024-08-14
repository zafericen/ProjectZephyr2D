using UnityEngine;

namespace ProjectZephyr
{

    public abstract class PlayerStateBase : MonoState
    {
        protected Animator animator;

        protected PlayerStateBase(GameObject o) : base(o)
        {
            animator = o.GetComponentInChildren<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            playStateAnimation();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public virtual void playStateAnimation() 
        { 
        }

    }

}



