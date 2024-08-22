using UnityEngine;

namespace ProjectZephyr
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 InputVector { get; private set; }

        public Vector3 MousePosition { get; private set; }

        private void Update()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            InputVector = new Vector2(h, 0);

            MousePosition = Input.mousePosition;
        }
    }
}