using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerRunState : PlayerStateBase
    {
        private Movement movement;

        public PlayerRunState(GameObject o) : base(o)
        {
            movement = o.GetComponent<Movement>();
        }

        public override void OnUpdate()
        {
            movement.Move();
            if (!movement.IsMoving())
            {
                busy = false;
                return;
            }

        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void playStateAnimation()
        {
            animator.Play("Running");
        }
        
    }
}