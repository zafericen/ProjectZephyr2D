using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class Ability: MonoBehaviour
    {
        private AbilityHolderBase ability = null;

        private void Start()
        {
            ChangeAbility(AbilitySlot.instance.GetAbility());
        }

        public void AbilityAttack()
        {
            ability.UseAbility();
        }

        public void ChangeAbility(GameObject abilityPrefab)
        {
            RemoveAbility();
            AssignAbility(abilityPrefab);
        }

        private void RemoveAbility()
        {
            if (ability == null)
            {
                return;
            }

            var toDestroy = ability;
            ability = null;
            Destroy(toDestroy.gameObject);

        }

        private void AssignAbility(GameObject abilityPrefab)
        {
            GameObject HolderObject = Instantiate(abilityPrefab, transform);
            ability = HolderObject.GetComponent<AbilityHolderBase>();
            ability.InitializeHolder(gameObject);
        }
    }
}