using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectZephyr
{
    public class PlayerWeaponSlots : MonoSingleton<PlayerWeaponSlots>
    {
        [SerializeField] private List<GameObject> slots;
        [SerializeField] private int currSlot;
        private bool doesChangeWeapon = true;


        public GameObject GetCurrentWeapon()
        {
            return slots[currSlot];
        }

        public void SetChangeWeaponFlag(bool changeWeapon)
        {
            doesChangeWeapon = changeWeapon;
        }

        public bool GetChangeWeaponFlag()
        {
            var returnBool = doesChangeWeapon;
            doesChangeWeapon = false;
            return returnBool;
        }

        public int NumberOfSlots()
        {
            return slots.Count;
        }

        public void ChangeCurrentIndex(int index)
        {
            if (index < 0 || index >= slots.Count)
            {
                Debug.LogError("Non-Valid Input to Slots");
                return;
            }
            currSlot = index;
        }

    }
}