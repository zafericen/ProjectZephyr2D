using UnityEngine;

namespace ProjectZephyr
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Camera cam;
        [SerializeField] private InputHandler inputHandler;
        Rigidbody2D rb;

        void Start ()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        public void Move()
        {
            var TargetVector = inputHandler.InputVector;
            rb.velocity = new Vector2(TargetVector.x,TargetVector.y);
            //var MovementVector = MoveTowardTarget(TargetVector.normalized);
            //RotateTowardMovementVector(MovementVector);
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