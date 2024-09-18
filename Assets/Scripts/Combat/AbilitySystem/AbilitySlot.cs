using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot : MonoSingleton<AbilitySlot>
{
    public List<GameObject> abilityHolders;  // A list to hold ability prefabs

    private void Start()
    {
        // For testing, let's assume we initialize the first ability as Dash
        // You can change this logic to add abilities dynamically based on player progress
        if (abilityHolders.Count > 0)
        {
            Debug.Log("Dash ability initialized from AbilitySlot.");
        }
    }

    public GameObject GetAbility()
    {
        // Return the first ability in the list (Dash or any other ability)
        if (abilityHolders.Count > 0)
        {
            return abilityHolders[0];
        }
        return null;
    }
}
