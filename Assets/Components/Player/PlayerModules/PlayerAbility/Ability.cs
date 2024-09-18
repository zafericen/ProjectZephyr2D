using UnityEngine;

public class Ability : MonoBehaviour
{
    public float cooldownTime = 1f;  // Default cooldown
    private bool isOnCooldown = false;

    private AbilityHolder abilityHolder;

    private void Start()
    {
        abilityHolder = GetComponent<AbilityHolder>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            abilityHolder.UseAbility(gameObject);
        }
    }

    // Use this method to trigger the ability
    public void TryActivate(GameObject user)
    {
        if (!isOnCooldown)
        {
            ActivateAbility(user);
            StartCooldown();
        }
    }

    // Start the cooldown after activation
    private void StartCooldown()
    {
        isOnCooldown = true;
        Invoke(nameof(ResetCooldown), cooldownTime);
    }

    private void ResetCooldown()
    {
        isOnCooldown = false;
    }

    // Each ability will implement its own behavior here
    protected virtual void ActivateAbility(GameObject user) { }
}
