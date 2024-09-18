using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] private Ability abilityPrefab; // Ability slot

    private Ability currentAbility;

    private void Start()
    {
        if (abilityPrefab != null)
        {
            // Instantiate and set the ability
            SetAbility(Instantiate(abilityPrefab));
        }
    }

    public void SetAbility(Ability newAbility)
    {
        // Clean up the previous ability if needed
        if (currentAbility != null)
        {
            Destroy(currentAbility.gameObject);
        }

        currentAbility = newAbility;
    }

    public void UseAbility(GameObject user)
    {
        if (currentAbility != null)
        {
            currentAbility.TryActivate(user);
        }
    }
}
