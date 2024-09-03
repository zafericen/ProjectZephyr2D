using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSlots : MonoSingleton<PlayerWeaponSlots>
{
    public List<GameObject> slots;


    public GameObject GetWeapon()
    {
        return slots[0];
    }

}
