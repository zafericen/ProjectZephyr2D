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
        private string jumpAnimationName = "Jumping";

        Animator animator;

        Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if(IsOnGround())
            {
                status = Status.SUCCESS;
            }
        }

        public void Jump()
        {
            rb.velocity = ((new Vector2(rb.velocity.x, jumpSpeed)));
        }

        public void StopJump()
        {
            rb.velocity = (new Vector2(rb.velocity.x, 0));
        }

        public bool IsOnGround()
        {
            if (Mathf.Approximately(rb.velocity.y, 0) && rb.GetContacts(GetComponents<CapsuleCollider2D>()) > 0) return true;
            return false;
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