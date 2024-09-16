using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerDodgeState : PlayerStateBase
    {
        private DodgeRoll dodgeRoll;

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            dodgeRoll = owner.GetComponent<DodgeRoll>();
            Debug.Log("girdi");
        }
        public override void OnUpdate()
        {
            if ((animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f && animator.GetCurrentAnimatorStateInfo(0).IsName("Dodging")))
            {
                status = StateStatus.Success;
            }
            dodgeRoll.Dodge();
        }

        public override void playStateAnimation()
        {
            animator.Play("Dodging",0,0);
        }
    }

}