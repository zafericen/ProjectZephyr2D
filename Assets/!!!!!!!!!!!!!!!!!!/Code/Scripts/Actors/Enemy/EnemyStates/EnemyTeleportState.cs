using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class EnemyTeleportState : EnemyStateBase
    {
        EnemyTeleport enemyTeleport;

        public EnemyTeleportState(GameObject o) : base(o)
        {
            enemyTeleport = o.GetComponent<EnemyTeleport>();
        }

        public override void OnEnter()
        {
            enemyTeleport.Move(enemyBehaviour.context.aims[0].transform);
        }

        public override void OnExit()
        {
            enemyTeleport.CancelTeleport();
            base.OnExit();
        }

        public override void InitialConnections()
        {
            
        }
    }

}