using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    public class EnemyAttackState : EnemyBaseState
    {
       

        public override void EnterState(EnemyStateManager enemy)
        {
          
            enemy.PlayerOnAttackRange = true;
            enemy.animator.SetBool(enemy.attackHash, true);
        }

        public override void UpdateState(EnemyStateManager enemy)
        {
            CheckSwitchState(enemy);

            
        }

        public override void CheckSwitchState(EnemyStateManager enemy)
        {
            if (enemy.healthScript.KnockedBacked)
            {
                enemy.SwitchState(enemy.hurtstate);
            }

            if (Vector3.Distance(enemy.transform.position, enemy.target.position) > enemy.Stats.AttackReach)
            {


                enemy.SwitchState(enemy.chasestate);

            }
        }
    }
}
