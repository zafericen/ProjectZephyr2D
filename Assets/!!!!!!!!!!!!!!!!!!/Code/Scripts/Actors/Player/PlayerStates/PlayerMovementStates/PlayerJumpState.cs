using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerJumpState : PlayerStateBase
    {
        private PlayerJump jumping;

        public PlayerJumpState(GameObject o) : base(o)
        {
            jumping = o.GetComponent<PlayerJump>();
        }

        public override bool IsBusy()
        {
            busy = !jumping.IsOnGround();
            return base.IsBusy();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            jumping.Jump();
        }

        public override void OnUpdate()
        {
            if (jumping.IsOnGround())
            {
                busy = false;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            jumping.StopJump();
        }


        public override void playStateAnimation()
        {
            animator.Play("Jumping");
        }

    }
}
