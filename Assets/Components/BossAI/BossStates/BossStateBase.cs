using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectZephyr
{
    public class BossStateBase : MonoState
    {
        protected Animator animator;
        public BossStateBase(GameObject o) : base(o)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            playStateAnimation();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public virtual void playStateAnimation()
        {
        }
    }
}
