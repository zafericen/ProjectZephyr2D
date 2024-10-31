using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class PlayerJump : State
    {
        [SerializeField]
        private float jumpSpeed = 1.0f;

        [SerializeField]
        private float jumpWalkSpeed = 10.0f;

        [SerializeField]
        private string jumpAnimationName = "Jumping";

        private Animator animator;
        private Rigidbody2D rb;
        private PlayerMovement playerMovement;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            playerMovement = GetComponent<PlayerMovement>(); 
        }

        private void Update()
        {
            if (IsOnGround())
            {
                status = Status.SUCCESS;
            }

            float airMovement = Input.GetAxis("Horizontal") * jumpWalkSpeed * Time.deltaTime;
            if(airMovement != 0)
            {
                playerMovement.Move(new Vector2(airMovement,0));
            }
        }

        public void Jump()
        {
            if (IsOnGround()) 
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }

        public void StopJump()
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        public bool IsOnGround()
        {
            return Mathf.Approximately(rb.velocity.y, 0) && rb.GetContacts(GetComponents<CapsuleCollider2D>()) > 0;
        }

        private void OnEnable()
        {
            status = Status.WORKING;
            Jump();
            animator.Play(jumpAnimationName);
        }

        private void OnDisable()
        {
            StopJump();
        }

        public override bool Check(Context context)
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}
