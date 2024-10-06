using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerIdleState: PlayerStateBase
    {
        public PlayerIdleState(GameObject o) : base(o)
        {
        }
        public override void OnEnter()
        {
            base.OnEnter();
            busy = false;
        }
        public override void playStateAnimation()
        {
            animator.Play("Idle");
        }
    }

}