using UnityEngine;

namespace ProjectZephyr
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Camera cam;
        [SerializeField] private PlayerInputHandler inputHandler;
        Rigidbody2D rb;
        bool facingRight = true;

        void Start ()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        public void Move()
        {
            var TargetVector = inputHandler.inputVector;
            if((TargetVector.x > 0 && !facingRight) || (TargetVector.x < 0 && facingRight))
            {
                FlipDirection();
            }
            rb.velocity = new Vector2(TargetVector.x*moveSpeed,rb.velocity.y);
            //var MovementVector = MoveTowardTarget(TargetVector.normalized);
            //RotateTowardMovementVector(MovementVector);
        }

        public bool IsMoving()
        {
            if(Mathf.Approximately(inputHandler.inputVector.x ,0))
            {
                return false;
            }
            else { return true; }
        }

        void FlipDirection()
        {
            Vector3 currScale = transform.localScale;
            currScale.x *= -1;
            transform.localScale = currScale;

            facingRight = !facingRight;
        }



        //private void RotateTowardMovementVector(Vector3 movementVector)
        //{
        //    if (movementVector.magnitude == 0)
        //    {
        //        return;
        //    }
        //    var Rotation = Quaternion.LookRotation(movementVector);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, rotationSpeed);
        //}

        //private Vector3 MoveTowardTarget(Vector3 TargetVector)
        //{
        //    var Speed = moveSpeed * Time.deltaTime;

        //    TargetVector = Quaternion.Euler(0, cam.gameObject.transform.eulerAngles.y, 0) * TargetVector;
        //    var TargetPosition = transform.position + TargetVector * Speed;
        //    transform.position = TargetPosition;

        //    return TargetVector;
        //}
        
    }


}