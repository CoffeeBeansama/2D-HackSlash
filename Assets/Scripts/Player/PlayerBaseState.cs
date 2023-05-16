using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Player.StateMachine
{
    public abstract class PlayerBaseState 
    {
        protected bool isRootState = false;
        protected PlayerStateMachine context;
        protected PlayerStateCache factory;
        protected PlayerBaseState currentSuperState;
        protected PlayerBaseState currentSubState;


        public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateCache stateFactory)
        {
            context = currentContext;
            factory = stateFactory;




        }


        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
        public abstract void CheckSwitchState();
        public abstract void InitializeSubState();
        public void UpdateStates()
        {


            UpdateState();
            if (currentSubState != null)
            {
                currentSubState.UpdateStates();
            }
        }

        public void SwitchStates(PlayerBaseState newState)
        {
            // current state exits state
            ExitState();

            // new state enters state

            newState.EnterState();


            if (isRootState)
            {
                // switching state
                context.CurrentState = newState;
            }
            else if (currentSuperState != null)
            {
                currentSuperState.SetSubState(newState);
            }
        }

        protected void SetSuperState(PlayerBaseState newSuperState)
        {
            currentSuperState = newSuperState;
        }

        protected void SetSubState(PlayerBaseState newSubState)
        {
            currentSubState = newSubState;
            newSubState.SetSuperState(this);

            newSubState.EnterState();
        }
    }
}
