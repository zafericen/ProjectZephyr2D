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

        public virtual void ResetAttackFragments()
        {

            foreach (var fragmentList in weapon.attackFragments)
            {
                fragmentList.currentNode = null;
            }
        }

        private void Attack(CurcilarLinkedList<AttackFragment> fragments, AttackType type)
        {
            timer.Reset();
            var fragment = weapon.attackFragments[(int)type].GetNext();
            weapon.Attack(fragment.Value);

        }
    }
    
}