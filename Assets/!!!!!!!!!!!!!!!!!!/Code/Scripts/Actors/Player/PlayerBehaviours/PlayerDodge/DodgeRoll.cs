using UnityEngine;

namespace ProjectZephyr
{
    public class DodgeRoll : MonoBehaviour
    {
        [SerializeField] private float slideSpeed = 20f;
        Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        public void Dodge()
        {
            rb.velocity = transform.right*Mathf.Sign(transform.localScale.x) * slideSpeed;
        }
    }
}