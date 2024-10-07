using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectZephyr
{
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

        private AttackFragment CheckComboFragment(StreamList<AttackInputType> stream)
        {
            var comboAttack = weapon.CheckComboStream(stream);
            if(comboAttack == null)
            {
                return null;
            }

            return comboAttack;
        }

        public void Attack(AttackInputType type)
        {
            CheckComboEnd();
            timer.Reset();
            var potentialComboAttack = CheckComboFragment(AttackStreamHandler.instance.stream);
            AttackFragment fragment;
            
            if (potentialComboAttack == null)
            {
                fragment = weapon.attackFragments[(int)type - 1].GetNext().Value;
            }
            else
            {
                fragment = potentialComboAttack;
                Debug.Log("eurika");
            }

            weapon.Attack(fragment);

            lastFragmentTime = fragment.FragmentTime();
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