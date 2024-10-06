using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public abstract class AttackStatesBase: PlayerStateBase, IStreamAddable<AttackInputType>
    {
        protected PlayerCombat combat;
        protected AttackInputType stateInputType;

        public IStream<AttackInputType> streamHandler { get; set; }

        protected AttackStatesBase(GameObject o) : base(o)
        {
            combat = o.GetComponent<PlayerCombat>();
            SetStateInput();
        }

        public override void OnEnter()
        {
            //The reason I didn't put this in the constructor, because I kept getting crashdowns from unity 
            //and I think the reason is this code tried to access the Unity Class intance without scene started
            //I have no proof but I will keep this here in case of something happening
            
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!combat.weapon.IsAttacking())
            {
                busy = false;
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            if (streamHandler == null)
            {
                InitializeStream(AttackStreamHandler.instance);
            }

            streamHandler.AddStream(stateInputType);
        }

        protected abstract void SetStateInput();

        public void InitializeStream(IStream<AttackInputType> stream)
        {
            streamHandler = stream;
        }

    }

}