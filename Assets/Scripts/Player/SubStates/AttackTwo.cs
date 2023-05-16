using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Controls;

namespace HackSlash.Player.StateMachine
{
    public class AttackTwo : PlayerBaseState
    {
        public AttackTwo(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
         : base(currentContext, stateFactory)
        {


        }

        public override void CheckSwitchState()
        {
            if (!context.CanContinueCombo) return;

            if (context.EndOfComboTwo)
            {
                if (context.AttackClicks > 2)
                {
                    SwitchStates(factory.AttackThree());
                }
                else
                {
                    context.Attacking = false;
                }
               

            }
          
        }

        public override void EnterState()
        {

            context.animator.SetBool(context.attackTwoHash, true);
            context.EndOfComboTwo = false;

           
        }

        public override void ExitState()
        {
            context.EndOfComboTwo = false;
            context.animator.SetBool(context.attackTwoHash, false);
    
        
        }

        public override void InitializeSubState()
        {

        }

        public override void UpdateState()
        {

       
            CheckSwitchState();
        }
    }
}
