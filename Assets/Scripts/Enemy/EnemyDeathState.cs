using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    public class EnemyDeathState : EnemyBaseState
    {
       

        public override void EnterState(EnemyStateManager enemy)
        {
            enemy.animator.SetBool(enemy.deathHash, true);
        }

        public override void UpdateState(EnemyStateManager enemy)
        {
           
        }


        public override void CheckSwitchState(EnemyStateManager enemy)
        {

        }
    }
}
