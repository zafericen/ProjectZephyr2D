using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerWalkState : PlayerStateBase
    {
        private Movement movement;

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            movement = owner.GetComponent<Movement>();
        }

        public override void OnUpdate()
        {
            movement.Move();
            if (!movement.IsMoving())
            {
                status = StateStatus.Success;
                return;
            }

        }

        public override void playStateAnimation()
        {
            animator.Play("Running");
        }
        

    }
}