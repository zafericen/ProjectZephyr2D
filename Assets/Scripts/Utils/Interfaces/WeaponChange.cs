using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class WeaponChange : MonoBehaviour
{
    public PlayerWeaponSlots weaponSlots;
    public GameObject gameCanvas;

    void Start()
    {
        UpdateCurrentWeapon();
        for (int i = 0; i < weaponSlots.slots.Count; i++) {
            AddWeaponToSlot(i);
        }
    }

    public void UpdateCurrentWeapon()
    {
        Image currentWeaponImage = gameCanvas.transform.GetChild(1).GetChild(1).GetComponent<Image>();

        GameObject weapon = weaponSlots.slots[weaponSlots.currSlot];

        string componentName = weapon.name;

        Type type = Type.GetType(componentName);

        if (type != null)
        {
            Component component = weapon.GetComponent(type);

            if (component != null)
            {
                var weaponSpriteField = type.GetField("weaponSprite");
                if (weaponSpriteField != null)
                {
                    currentWeaponImage.sprite = (Sprite)weaponSpriteField.GetValue(component);
                }
            }
        }

        Color tempColor = currentWeaponImage.color;
        tempColor.a = 1f;
        currentWeaponImage.color = tempColor;
    }

    public void AddWeaponToSlot(int weaponIndex)
    {
        Image weaponImage = gameCanvas.transform.GetChild(0).GetChild(weaponIndex).GetChild(0).GetComponent<Image>();

        GameObject weapon = weaponSlots.slots[weaponIndex];

        string componentName = weapon.name;

        // Get the type of the component using reflection
        Type type = Type.GetType(componentName);

        if (type != null)
        {
            // Use reflection to get the component of that type
            Component component = weapon.GetComponent(type);

            if (component != null)
            {
                var weaponSpriteField = type.GetField("weaponSprite");
                if (weaponSpriteField != null)
                {
                    // Set the sprite of the current weapon image
                    weaponImage.sprite = (Sprite)weaponSpriteField.GetValue(component);
                }
            }
        }

        // Set the alpha of the weapon image to 1
        Color tempColor = weaponImage.color;
        tempColor.a = 1f;
        weaponImage.color = tempColor;
    }

    public void OpenWeaponSelection()
    {
        gameCanvas.transform.GetChild(0).gameObject.SetActive(true);
    }
}
