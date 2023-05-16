using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Controls;

namespace HackSlash.Player.StateMachine
{
    public class PlayerGroundedStates : PlayerBaseState
    {

        public PlayerGroundedStates(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
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

            if (PlayerInput.PressingRoll)
            {
                SwitchStates(factory.RollState());
            }

            if (PlayerInput.PressingAttackKeyButton)
            {
            
                SwitchStates(factory.AttackState());



            }
        }

        public override void EnterState()
        {
            InitializeSubState();

        }

        public override void ExitState()
        {
            context.animator.SetBool(context.walkHash, false);
            context.animator.SetBool(context.idleHash, false);
        }

        public override void InitializeSubState()
        {
           
            SetSubState(factory.IdleState());
        }

        public override void UpdateState()
        {
    
            

            CheckSwitchState();
        }
    }
}
