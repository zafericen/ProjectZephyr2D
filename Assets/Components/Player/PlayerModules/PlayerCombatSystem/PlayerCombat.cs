using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private GameObject weaponPrefab;

        public WeaponBase weapon { get; set; }

        private enum AttackType
        {
            NORMAL_ATTACK,
            SPECIAL_ATTACK,
            WEAPON_ART,
        }

        private Timer timer = new Timer();

        private float lastFragmentTime = 0;
       
        private void Start()
        {
            GameObject weaponObject = Instantiate(weaponPrefab,this.transform);
            weapon = weaponObject.GetComponent<WeaponBase>();
            weapon.InitializeWeapon(gameObject);
        }

        public virtual void NormalAttack()
        {
            Attack(weapon.normalAttackFragments, AttackType.NORMAL_ATTACK);
        }

        public virtual void SpecialAttack()
        {
            Attack(weapon.specialAttackFragments, AttackType.SPECIAL_ATTACK);
        }

        public virtual void WeaponArt()
        {
            Attack(weapon.weaponArtFragments, AttackType.WEAPON_ART);
        }

        protected virtual void CheckComboEnd()
        {
            if (timer.Seconds() > 1 + lastFragmentTime)
            {
                for(int i = 0; i < weapon.fragmentIndices.Count; ++i)
                {
                    weapon.fragmentIndices[i] = 0;
                }
            }
        }

        private void Attack(List<AttackFragment> fragments, AttackType type)
        {
            CheckComboEnd();
            timer.Reset();
            int index = weapon.fragmentIndices[(int)type];
            weapon.Attack(fragments[index]);
            lastFragmentTime = fragments[index].FragmentTime();

            weapon.fragmentIndices[(int)type] += 1;
            weapon.fragmentIndices[(int)type] %= fragments.Count;
        }
    }
    
}