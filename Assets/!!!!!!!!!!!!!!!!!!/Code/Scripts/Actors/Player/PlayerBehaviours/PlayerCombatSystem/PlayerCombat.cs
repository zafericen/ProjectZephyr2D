using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectZephyr
{

    public enum AttackType
    {
        NORMAL_ATTACK,
        SPECIAL_ATTACK,
        WEAPON_ART,
    }
    public class PlayerCombat : MonoBehaviour
    {
        public WeaponBase weapon { get; set; }

        public string weaponType;

        private Timer timer = new Timer();

        private float lastFragmentTime = 0;


        private void Update()
        {
            if (PlayerWeaponSlots.instance.GetChangeWeaponFlag())
            {
                ChangeWeapon(PlayerWeaponSlots.instance.GetCurrentWeapon());
            }
        }

        public virtual void CheckComboEnd()
        {
            if (timer.Seconds() > lastFragmentTime + 0.3)
            {
                foreach (var fragmentList in weapon.attackFragments)
                {
                    fragmentList.currentNode = null;
                }
            }
        }

        public void Attack(AttackType type)
        {
            CheckComboEnd();
            timer.Reset();
            var fragment = weapon.attackFragments[(int)type].GetNext();
            weapon.Attack(fragment.Value);

            lastFragmentTime = fragment.Value.FragmentTime();
        }

        public void ChangeWeapon(GameObject weaponPrefab)
        {
            DropWeapon();
            AssignWeapon(weaponPrefab);
            weaponType = weapon.GetType().Name;
        }

        private void DropWeapon()
        {
            if(weapon == null)
            {
                return;
            }

            var toDestroy = weapon;
            weapon = null;
            Destroy(toDestroy.gameObject);

        }

        private void AssignWeapon(GameObject weaponPrefab)
        {
            GameObject weaponObject = Instantiate(weaponPrefab, transform);
            weapon = weaponObject.GetComponent<WeaponBase>();
            weapon.InitializeWeapon(gameObject);
        }
    }
    
}