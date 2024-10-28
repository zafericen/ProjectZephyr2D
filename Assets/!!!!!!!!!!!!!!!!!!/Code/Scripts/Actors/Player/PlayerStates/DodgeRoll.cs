using UnityEngine;

namespace ProjectZephyr
{
    public class DodgeRoll : State
    {
        [SerializeField] 
        private float slideSpeed = 20f;

        [SerializeField]
        private string dodgeAnimationName = "Dodging";

        Animator animator;

        Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            Dodge();

            var currentState = animator.GetCurrentAnimatorStateInfo(0);

            if (currentState.IsName(dodgeAnimationName) && currentState.normalizedTime >= 1.0f)
            {
                status = Status.SUCCESS;
            }
        }

        public void Dodge()
        {
            rb.velocity = transform.right * Mathf.Sign(transform.localScale.x) * slideSpeed;
        }

        public override bool Check(Context context)
        {
            return Input.GetKeyDown(KeyCode.F);
        }

        private void OnEnable()
        {
            status = Status.WORKING;
            animator.Play(dodgeAnimationName, 0, 0);
        }
    }
}