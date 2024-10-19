using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public abstract class AttackStatesBase: PlayerStateBase, IStreamAddable<AttackInputType>
    {
        protected PlayerCombat combat;
        protected AttackInputType stateInputType;
        protected bool isPerfectAttack;

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
            if(streamHandler == null)
            {
                InitializeStream(AttackStreamHandler.instance);
            }

            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            isPerfectAttack = combat.weapon.IsPerfectAttacking();

            if (!combat.weapon.IsAttacking())
            {
                busy = false;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log(isPerfectAttack);
            if (isPerfectAttack)
            {
                PerfectAttackLogic();
            }
            else
            {
                streamHandler.stream.Clear();
            }

            combat.gameObject.GetComponentInChildren<PlayerAnimationEventHandler>().NotAttacking();
        }

        protected abstract void SetStateInput();

        protected virtual void PerfectAttackLogic()
        {
            //TODO: VFX
            combat.gameObject.GetComponentInChildren<PlayerAnimationEventHandler>().NotPerfectAttacking();
            sendContext.isPerfectAttack = true;
            combat.gameObject.GetComponentInChildren<PlayerAnimationEventHandler>().Flash();
            streamHandler.AddStream(stateInputType);

        }

        public void InitializeStream(IStream<AttackInputType> stream)
        {
            streamHandler = stream;
        }

        public override bool ValidateInputAndUpdateContext(InputContext compareContext)
        {
            var gottenInputType = InputHandler.instance.GetInput(compareContext.type, compareContext.holdType);
            
            if(gottenInputType.attackType == compareContext.attackType)
            {
                sendContext.inputContext = gottenInputType;
                return true;
            }
            return false;
        }

    }

}