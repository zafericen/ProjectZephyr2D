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
            if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
            {
                busy = false;
                return;
            }

            movement.Move();
        }

        public override void playStateAnimation()
        {
            animator.Play("Running");
        }
        
    }
}