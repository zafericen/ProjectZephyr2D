using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float jumpSpeed;
        Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
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
    }
}