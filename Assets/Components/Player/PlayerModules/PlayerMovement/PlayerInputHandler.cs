using UnityEngine;

namespace ProjectZephyr
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 inputVector { get; internal set; }

        private void Start()
        {
            var actions = InputHandler.instance.playerInputActions;

            actions.Movement.Walking.performed += Walking_performed;
            actions.Movement.Walking.canceled += Walking_canceled;
        }

        private void Walking_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            inputVector = Vector2.zero;
        }

        private void Walking_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

    }
}