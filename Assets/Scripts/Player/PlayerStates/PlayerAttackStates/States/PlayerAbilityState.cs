namespace ProjectZephyr
{
    public partial class PlayerAbilityState : AttackStatesBase
    {
        Ability ability;

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            ability = owner.GetComponent<Ability>();
            ability.AbilityAttack();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        protected override void SetStateInput()
        {
            stateInputType = AttackInputType.Ability;
        }

    }
}
