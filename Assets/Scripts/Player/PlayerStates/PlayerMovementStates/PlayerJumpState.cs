using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerJumpState : PlayerStateBase
    {
        private PlayerJump jumping;

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            jumping = owner.GetComponent<PlayerJump>();
            jumping.Jump();
        }

        public override void OnUpdate()
        {
            if (jumping.IsOnGround())
            {
                status = StateStatus.Success;
            }
        }

        public override void OnExit(MachineContext context)
        {
            base.OnExit(context);
            jumping.StopJump();
        }


        public override void playStateAnimation()
        {
            animator.Play("Jumping");
        }

    }
}
