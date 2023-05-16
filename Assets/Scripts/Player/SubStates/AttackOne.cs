using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Controls;

namespace HackSlash.Player.StateMachine
{
    public class AttackOne : PlayerBaseState
    {
        public AttackOne(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
        : base(currentContext, stateFactory)
        {
            

        }

        public override void CheckSwitchState()
        {
            if (!context.CanContinueCombo) return;

            if (context.EndOfAttackOne)
            {
                if (context.AttackClicks > 1)
                {
                    
                    SwitchStates(factory.AttackTwo());
                }
                else
                {
            
                    context.Attacking = false;
                }
                

            }
           
                     
            
        }

        public override void EnterState()
        {

            context.animator.SetBool(context.attackOneHash, true);
            context.EndOfAttackOne = false;
            SoundManager.instance.PlaySound(context.AttackOneSfx);
        }

        public override void ExitState()
        {
            context.EndOfAttackOne = false;
            context.animator.SetBool(context.attackOneHash, false);
           

        }

        public override void InitializeSubState()
        {

        }

        public override void UpdateState()
        {
            Debug.Log("AttackOne");


            CheckSwitchState();
        }
    }
}
