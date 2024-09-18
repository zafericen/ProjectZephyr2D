using System;
using UnityEngine;

namespace ProjectZephyr
{
    public partial class PlayerAbilityState : AttackStatesBase
    {
        private AbilityHolder abilityHolder;
        private GameObject player;

        public PlayerAbilityState(GameObject o) : base(o)
        {
            player = o; // Store the reference to the game object
            abilityHolder = player.GetComponent<AbilityHolder>(); // Get the AbilityHolder component from the player
        }

        public override void OnEnter()
        {
            base.OnEnter();
            // Check if AbilityHolder and the player reference are valid
            if (abilityHolder != null && player != null)
            {
                abilityHolder.UseAbility(player);  // Pass the stored player object as the user
            }
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
