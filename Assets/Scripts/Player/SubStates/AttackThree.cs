using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Player.StateMachine
{
    public class AttackThree : PlayerBaseState
    {
        public AttackThree(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
         : base(currentContext, stateFactory)
        {


        }

        public override void CheckSwitchState()
        {

        }

        public override void EnterState()
        {
            context.animator.SetBool(context.attackThreeHash, true);
          
        }

        public override void ExitState()
        {
           
            context.animator.SetBool(context.attackThreeHash, false);
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
