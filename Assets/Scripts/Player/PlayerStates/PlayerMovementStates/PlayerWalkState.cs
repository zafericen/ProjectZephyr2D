using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerWalkState : PlayerStateBase
    {
        private Movement movement;

        public PlayerWalkState(GameObject o) : base(o)
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