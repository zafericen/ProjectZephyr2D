using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public class Idle : State
    {
        Animator animator;

        [SerializeField]
        private string idleAnimationName = "Idle";

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public override bool Check(Context context)
        {
            return context.current.status != Status.WORKING;
        }

        void OnEnable()
        {
            status = Status.SUCCESS;
            animator.Play(idleAnimationName);
        }
    }
}
