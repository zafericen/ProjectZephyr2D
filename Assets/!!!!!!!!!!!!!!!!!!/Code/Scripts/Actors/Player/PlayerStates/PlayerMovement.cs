using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{
    public class PlayerMovement : Movement
    {
        private Animator animator;

        [SerializeField]
        private string movementAnimationName = "Running";

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            Vector2 inputVector = new Vector2(
                Input.GetAxis("Horizontal"),
                0
            ).normalized;

            Move(inputVector);

            if (inputVector.magnitude == 0)
            {
                status = Status.SUCCESS;
            }
        }

        public override bool Check(Context context)
        {
            return context.current.status != Status.WORKING && CheckInput();
        }

        private void OnEnable()
        {
            status = Status.WORKING;
            animator.Play(movementAnimationName);
        }

        private bool CheckInput()
        {
            return Input.GetAxis("Horizontal") != 0;
        }
    }
}
