using UnityEngine;

namespace ProjectZephyr
{

    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform referenceObject;
        [SerializeField]private float followSpeed = 0.125f;
        [SerializeField]private Vector3 offset;
        
        
        private void LateUpdate()
        {
            Vector3 desiredPosition = referenceObject.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed);
            transform.position = smoothedPosition;
        }
    }

}