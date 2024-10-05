using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public enum DamageType
    {
        NORMAL_DAMAGE,
        SLASH_DAMAGE,
    }

    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth;
        [SerializeField] int currentHealth;

        [SerializeField]
        List<int> defenses = new List<int>()
    {
        50, 50,
    };

        public void TakeDamage(float damage, DamageType damageType)
        {
            float final = (defenses[(int)damageType] / 100.0f) * damage;
            Debug.Log(final);
            currentHealth -= (int)final;
        }
    }
}