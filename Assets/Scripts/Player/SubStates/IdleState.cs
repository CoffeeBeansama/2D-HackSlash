using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Controls;

namespace HackSlash.Player.StateMachine
{
    public class IdleState : PlayerBaseState
    {

        public IdleState(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
        : base(currentContext, stateFactory)
        {

        }

       

        public override void EnterState()
        {
            
            context.animator.SetBool(context.idleHash, true);

            
        }

        public override void CheckSwitchState()
        {

          

            if(PlayerInput.PressingLeft || PlayerInput.PressingRight)
            {
            
                SwitchStates(factory.WalkState());
            }
        }

        public override void ExitState()
        {
            context.animator.SetBool(context.idleHash, false);
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
