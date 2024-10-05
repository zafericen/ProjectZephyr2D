using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace ProjectZephyr
{
    public class WeaponChange : MonoBehaviour
    {
        [SerializeField] private PlayerWeaponSlots weaponSlots;
        [SerializeField] private GameObject gameCanvas;

        void Start()
        {
            weaponSlots = PlayerWeaponSlots.instance;

            UpdateCurrentWeapon();
            for (int i = 0; i < weaponSlots.NumberOfSlots(); i++)
            {
                AddWeaponToSlot(i);
            }
        }

        public void UpdateCurrentWeapon()
        {
            Image currentWeaponImage = gameCanvas.transform.GetChild(1).GetChild(1).GetComponent<Image>();

            GameObject weapon = weaponSlots.GetCurrentWeapon();

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


            weaponSlots.ChangeCurrentIndex(weaponIndex);
            GameObject weapon = weaponSlots.GetCurrentWeapon();

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
                        weaponImage.sprite = (Sprite)weaponSpriteField.GetValue(component);
                    }
                }
            }

            Color tempColor = weaponImage.color;
            tempColor.a = 1f;
            weaponImage.color = tempColor;
        }

        public void OpenWeaponSelection()
        {
            InputHandler.instance.DisableAllInputMaps();
            gameCanvas.transform.GetChild(0).gameObject.SetActive(true);
        }
        public void CloseWeaponSelection()
        {
            gameCanvas.transform.GetChild(0).gameObject.SetActive(false);
            InputHandler.instance.EnableAllInputMaps();
        }

        public void SelectWeapon(int weaponIndex)
        {
            weaponSlots.ChangeCurrentIndex(weaponIndex);
            UpdateCurrentWeapon();
            weaponSlots.SetChangeWeaponFlag(true);
            CloseWeaponSelection();
        }
    }
}