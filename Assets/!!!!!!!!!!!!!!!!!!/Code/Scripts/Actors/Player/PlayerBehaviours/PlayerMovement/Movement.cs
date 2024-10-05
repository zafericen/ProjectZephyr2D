using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Camera cam;
        Rigidbody2D rb;
        bool facingRight = true;
        bool isMoving;


        void Start ()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        public void Move()
        {
            var input = InputHandler.instance.GetInput(InputType.Walk, InputActionPhase.Performed);
            if (input.type != InputType.None) { isMoving = true; }
            else { isMoving = false; return; }


            var TargetVector = input.inputVector;
            if((TargetVector.x > 0 && !facingRight) || (TargetVector.x < 0 && facingRight))
            {
                FlipDirection();
            }
            rb.velocity = new Vector2(TargetVector.x*moveSpeed,rb.velocity.y);    
        }

        public bool IsMoving()
        {
            return isMoving;
        }

        void FlipDirection()
        {
            Vector3 currScale = transform.localScale;
            currScale.x *= -1;
            transform.localScale = currScale;

            facingRight = !facingRight;
        }
        
    }


}