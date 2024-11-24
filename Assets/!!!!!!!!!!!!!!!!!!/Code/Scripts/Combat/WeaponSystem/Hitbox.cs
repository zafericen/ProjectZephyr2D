using ProjectZephyr;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damageMultiplier = 1f;
    private Collider2D hitboxCollider;

    private void Awake()
    {
        hitboxCollider = GetComponent<Collider2D>();
        hitboxCollider.enabled = false; // Start disabled
    }

    public void EnableHitbox(float duration)
    {
        hitboxCollider.enabled = true;
        Invoke(nameof(DisableHitbox), duration);
    }

    private void DisableHitbox()
    {
        hitboxCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("Dokundu");
        // Check if collision object has a damageable component
        var damageable = collision.GetComponent<Enemy>();
        if (damageable != null)
        {
            Debug.Log("Düşman");
            damageable.TakeDamage(damageMultiplier);
        }
    }
}