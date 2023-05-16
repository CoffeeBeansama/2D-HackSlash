using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    public class EnemyHurtState : EnemyBaseState
    {
        float HurtTimer;
        float KnockBackforce = 14f;

      

        public override void EnterState(EnemyStateManager enemy)
        {

            PlayHurtSound();

            HurtTimer = 0.20f;
            enemy.animator.SetBool(enemy.hurtHash, true);
        


        }

        public override void UpdateState(EnemyStateManager enemy)
        {
            CheckSwitchState(enemy);
         



                    
           KnockBack(enemy);
                  
       

         
           


           

            
         


        }


        public override void CheckSwitchState(EnemyStateManager enemy)
        {
            if(!enemy.healthScript.KnockedBacked)
            {
                enemy.SwitchState(enemy.chasestate);
                enemy.animator.SetBool(enemy.hurtHash, false);
            }
        }



        void PlayHurtSound()
        {
            if (!SoundManager.instance.HurtSource.isPlaying)
            {
                SoundManager.instance.HurtSource.Play();
            }

        }
        void KnockBack(EnemyStateManager enemy)
        {
            HurtTimer -= Time.deltaTime;


            if (HurtTimer <= 0f)
            {
               
                enemy.healthScript.KnockedBacked = false;
             
                
            }

            if (enemy.transform.position.x > enemy.target.position.x) //Going Left
            {
                enemy.transform.position += Vector3.right * KnockBackforce * Time.fixedDeltaTime;
            }

            if (enemy.transform.position.x < enemy.target.position.x) //Going Right
            {
                enemy.transform.position += Vector3.left * KnockBackforce * Time.fixedDeltaTime;
            }
        }

        
    }
    public delegate void HurtSound();
}
