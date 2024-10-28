using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public class Attack : State
    {

        StateMachine machine;

        private void Awake()
        {
            machine = transform.GetChild(0).GetComponentInChildren<StateMachine>();
            machine.enabled = false;
        }

        public void Update()
        {
            if (machine.context.current != null && machine.context.current.GetType() == typeof(Exit))
            {
                status = Status.SUCCESS;
            }
        }

        public override bool Check(Context context)
        {
            return Input.GetKeyDown(KeyCode.Q);
        }

        void OnEnable()
        {
            status = Status.WORKING;
            machine.enabled = true;
        }

        private void OnDisable()
        {
            machine.enabled = false;
        }
    }
}
