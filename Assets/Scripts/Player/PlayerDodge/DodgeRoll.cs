using UnityEngine;

namespace ProjectZephyr
{
    public class DodgeRoll : MonoBehaviour
    {
        [SerializeField] private float slideSpeed = 20f;


        public void Dodge()
        {
            transform.position += transform.forward * slideSpeed * Time.deltaTime;
        }
    }
}