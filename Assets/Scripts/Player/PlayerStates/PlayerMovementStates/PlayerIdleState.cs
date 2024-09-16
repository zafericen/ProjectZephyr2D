using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerIdleState : PlayerStateBase
    {
        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            status = StateStatus.Success;
        }

        public override void playStateAnimation()
        {
            animator.Play("Idle");
        }
    }

}