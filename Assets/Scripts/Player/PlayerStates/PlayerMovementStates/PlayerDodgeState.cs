using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerDodgeState : PlayerStateBase
    {
        private DodgeRoll dodgeRoll;

        public PlayerDodgeState(GameObject o) : base(o)
        {
            dodgeRoll = o.GetComponent<DodgeRoll>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("girdi");
        }
        public override void OnUpdate()
        {
            if ((animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f && animator.GetCurrentAnimatorStateInfo(0).IsName("Dodging")))
            {
                busy = false;
            }
            dodgeRoll.Dodge();
        }



        public override void playStateAnimation()
        {
            animator.Play("Dodging",0,0);
        }
    }

}