using UnityEngine;

namespace ProjectZephyr
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 InputVector { get; private set; }

        public Vector3 MousePosition { get; private set; }

        private void Update()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            InputVector = new Vector2(h, 0);

            MousePosition = Input.mousePosition;
        }
    }
}