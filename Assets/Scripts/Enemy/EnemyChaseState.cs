using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    public class EnemyChaseState : EnemyBaseState
    {
        public override void EnterState(EnemyStateManager enemy)
        {
            enemy.animator.SetBool(enemy.attackHash, false);
            enemy.PlayerOnAttackRange = false;
        }

        public override void UpdateState(EnemyStateManager enemy)
        {

            CheckSwitchState(enemy);


            if (enemy.transform.position.x > enemy.target.position.x) //Going Left
            {
                enemy.spriteRenderer.flipX = true;

                enemy.transform.position += Vector3.left * enemy.Stats.MovementSpeed * Time.fixedDeltaTime;

            }

            if (enemy.transform.position.x < enemy.target.position.x) //Going Right
            {
                enemy.spriteRenderer.flipX = false;
                enemy.transform.position += Vector3.right * enemy.Stats.MovementSpeed * Time.fixedDeltaTime;
            }


         


        }

        public override void CheckSwitchState(EnemyStateManager enemy)
        {

            if (enemy.healthScript.EnemyDead)
            {
                enemy.SwitchState(enemy.deathstate);
            }

            if (enemy.healthScript.KnockedBacked)
            {

                enemy.SwitchState(enemy.hurtstate);
            }

            if (Vector3.Distance(enemy.transform.position, enemy.target.position) < enemy.Stats.AttackReach)
            {
             
                enemy.SwitchState(enemy.attackstate);

            }


        

            
        }
    }
}
