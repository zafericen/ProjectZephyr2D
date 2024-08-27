using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;

    public AbilitySlotBase slot { get; set; }


    private Timer timer = new Timer();

    private float lastFragmentTime = 0;

    private void Start()
    {
        GameObject weaponObject = Instantiate(slotPrefab, this.transform);
        slot = weaponObject.GetComponent<AbilitySlotBase>();
        slot.InitializeAbilities(gameObject);
    }

    public virtual void AbilityAttack()
    {
        Attack(slot.abilityFragments);
    }


    protected virtual void CheckComboEnd()
    {
        if (timer.Seconds() > 1 + lastFragmentTime)
        {
            for (int i = 0; i < slot.fragmentIndices; ++i)
            {
                slot.fragmentIndices = 0;
            }
        }
    }

    private void Attack(List<AttackFragment> fragments)
    {
        CheckComboEnd();
        timer.Reset();
        int index = slot.fragmentIndices;
        slot.Attack(fragments[index]);
        lastFragmentTime = fragments[index].FragmentTime();

        slot.fragmentIndices += 1;
        slot.fragmentIndices %= fragments.Count;
    }
}
