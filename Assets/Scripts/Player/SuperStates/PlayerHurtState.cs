using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Player.StateMachine
{
    public class PlayerHurtState : PlayerBaseState
    {
        public PlayerHurtState(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
        : base(currentContext, stateFactory)
        {

            isRootState = true;
        }

        public override void CheckSwitchState()
        {
            if (!context.Damaged)
            {
                SwitchStates(factory.Grounded());
            }
        }

        public override void EnterState()
        {
            context.animator.SetBool(context.HurtHash, true);
            InitializeSubState();
            
        }

        public override void ExitState()
        {

            context.animator.SetBool(context.HurtHash, false);
        }

        public override void InitializeSubState()
        {

        }

        public override void UpdateState()
        {
            context.animator.SetBool(context.HurtHash, true);

            Debug.Log("Update from hurt state");

            CheckSwitchState();
        }
    }
}
