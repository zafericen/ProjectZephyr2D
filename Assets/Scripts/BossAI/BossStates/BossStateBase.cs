using UnityEngine;

namespace ProjectZephyr
{
    public class BossStateBase : State
    {
        protected Animator animator;
        protected GameObject o;

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            o = context.owner;
            animator = o.GetComponent<Animator>();
            playStateAnimation();
        }

        public virtual void playStateAnimation()
        {
        }
    }
}
