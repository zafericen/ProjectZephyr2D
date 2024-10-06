using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectZephyr
{

    [RequireComponent(typeof(SimpleFlash))]
    public class PlayerAnimationEventHandler : MonoBehaviour, IInvincible, IAttacking
    {
        bool isInvincible;
        bool isAttacking;
        SimpleFlash simpleFlash;

        private void Start()
        {
            simpleFlash = GetComponent<SimpleFlash>();
        }

        public void Attacking()
        {
            isAttacking = true;
        }

        public void Flash()
        {
            simpleFlash.Flash();
        }

        public bool IsAttacking()
        {
            return isAttacking;
        }

        public void NotAttacking()
        {
            isAttacking = false;
        }
        public bool IsInvincible()
        {
            return isInvincible;
        }

        public void MakeInvincible()
        {
            Debug.Log("IsInvincible");
        }

        public void TakeInvincible()
        {
            isInvincible = false;
        }
    }

    interface IInvincible
    {
        public bool IsInvincible();

        public void MakeInvincible();

        public void TakeInvincible();
    }

    interface IAttacking
    {
        public bool IsAttacking();

        public void Attacking();

        public void NotAttacking();
    }

    interface IPerfectAttacking
    {

    }
}