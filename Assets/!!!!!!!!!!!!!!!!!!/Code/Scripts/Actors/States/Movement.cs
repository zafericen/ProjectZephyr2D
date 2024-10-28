using UnityEngine;

namespace ProjectZephyr
{
    public enum Direction
    {
        Left,
        Right,
    }

    public class Movement : State
    {
        [SerializeField]
        protected float moveSpeed;
        [SerializeField]
        protected float rotationSpeed;
        [SerializeField]
        protected Direction direction = Direction.Right;

        protected Rigidbody2D rb;

        public void Move(Vector2 inputVector)
        {
            if (inputVector.x > 0 && direction == Direction.Left)
            {
                FlipDirection();
            }
            else if (inputVector.x < 0 && direction == Direction.Right)
            {
                FlipDirection();
            }

            rb.velocity = new Vector2(inputVector.x * moveSpeed, rb.velocity.y);
        }

        void FlipDirection()
        {
            Vector3 currScale = transform.localScale;
            currScale.x *= -1;
            transform.localScale = currScale;
            direction = (direction == Direction.Right) ? Direction.Left : Direction.Right;
        }
    }
}
