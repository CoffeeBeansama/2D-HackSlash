using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Player.StateMachine
{
    public class PlayerAttackState : PlayerBaseState
    {
        public PlayerAttackState(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
        : base(currentContext, stateFactory)
        {
            isRootState = true;

        }

        public override void CheckSwitchState()
        {
            if (context.Damaged)
            {
                SwitchStates(factory.HurtState());
            }

            if (context.Attacking == false)
            {
                SwitchStates(factory.Grounded());
            }
        }

        public override void EnterState()
        {
            context.Attacking = true;
            InitializeSubState();
           
           
      
            
          
        }

        public override void ExitState()
        {
            context.animator.SetBool(context.attackOneHash, false);
            context.animator.SetBool(context.attackTwoHash, false);
            context.animator.SetBool(context.attackThreeHash, false);
            context.AttackClicks = 0;

        }

        public override void InitializeSubState()
        {
            SetSubState(factory.AttackOne());
         
        }

        public override void UpdateState()
        {
          
            CheckSwitchState();
    
        }

   
    }
}
