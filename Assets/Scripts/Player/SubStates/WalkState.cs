using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Controls;

namespace HackSlash.Player.StateMachine
{
    public class WalkState : PlayerBaseState
    {
        public WalkState(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
         : base(currentContext, stateFactory)
        {

        }

        public override void CheckSwitchState()
        {

        }

        public override void EnterState()
        {
            context.animator.SetBool(context.walkHash, true);
        }

        public override void ExitState()
        {
            context.animator.SetBool(context.walkHash, false);
        }

        public override void InitializeSubState()
        {

        }

        public override void UpdateState()
        {
           
            
            HandleMovement(context);

            CheckSwitchState();

        }

        public void HandleMovement(PlayerStateMachine context)
        {

            Debug.Log("walk state");

            if (PlayerInput.PressingLeft)
            {
                context.rigidbody.position += Vector2.left * context.Stats.MovementSpeed * Time.fixedDeltaTime;
                
                
                context._playerXscale.x = -1;
            }
            else if (PlayerInput.PressingRight)
            {
                context.rigidbody.position += Vector2.right * context.Stats.MovementSpeed * Time.fixedDeltaTime;

               

                context._playerXscale.x = 1;
            }
            else
            {
                SwitchStates(factory.IdleState());
            }

          



            context.transform.localScale = context._playerXscale;
        }
            
    }
}
