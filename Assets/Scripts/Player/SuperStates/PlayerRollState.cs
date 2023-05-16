using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Controls;

namespace HackSlash.Player.StateMachine
{
    public class PlayerRollState : PlayerBaseState
    {

        bool Rolled = false;
        float KnockBackforce = 14f;

        public PlayerRollState(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
       : base(currentContext, stateFactory)
        {
            isRootState = true;

        }
        public override void CheckSwitchState()
        {
            
        }

        public override void EnterState()
        {

           
            context.Rolling = true;

           
        }

        public override void ExitState()
        {
            context.animator.SetBool(context.RollHash, false);
        }

        public override void InitializeSubState()
        {
           
        }

        public override void UpdateState()
        {
            
            context.animator.SetBool(context.RollHash, true);
           HandleMovement(context);
        }

        void HandleMovement(PlayerStateMachine ctx)
        {
          


            if (context.Rolling == false)
            {

                SwitchStates(factory.Grounded());


            }

            bool FacingLeft = context._playerXscale.x == -1;
            bool FacingRight = context._playerXscale.x == 1;

            if (FacingLeft)
            {
                ctx.transform.position += Vector3.left * KnockBackforce * Time.fixedDeltaTime;
               


            }else if (FacingRight)
            {
                ctx.transform.position += Vector3.right * KnockBackforce * Time.fixedDeltaTime;
            }

           
        }

        
    }
}
