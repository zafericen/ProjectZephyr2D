using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        rb.AddForce((new Vector2(rb.velocity.x, jumpForce)));
    }

    public bool IsOnGround()
    {
        if (Mathf.Approximately(rb.velocity.y, 0)) return true;
        return false;
    }
}
