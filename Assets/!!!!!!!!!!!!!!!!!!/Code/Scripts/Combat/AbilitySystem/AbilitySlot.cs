using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class AbilitySlot : MonoSingleton<AbilitySlot>
    {
        public List<GameObject> abilityHolders;


        public GameObject GetAbility()
        {
            return abilityHolders[0];
        }
    }
}
