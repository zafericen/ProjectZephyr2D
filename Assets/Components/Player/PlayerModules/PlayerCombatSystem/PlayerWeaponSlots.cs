using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSlots : MonoSingleton<PlayerWeaponSlots>
{
    public List<GameObject> slots;
    public int currSlot;


    public GameObject GetWeapon()
    {
        return slots[currSlot];
    }

}
