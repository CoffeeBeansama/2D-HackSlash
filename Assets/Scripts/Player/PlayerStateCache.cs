using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Player.StateMachine
{

    public enum PlayerStates
    {
        Grounded, Walk, Idle,
        Attack, AttackOne,AttackTwo,AttackThree,

        Roll,
        Hurt,

        
      
        Death
    }
    public class PlayerStateCache
    {
        PlayerStateMachine context;
        Dictionary<PlayerStates, PlayerBaseState> _states = new Dictionary<PlayerStates, PlayerBaseState>();


        public PlayerStateCache(PlayerStateMachine currentContext)
        {
            context = currentContext;

            _states[PlayerStates.Grounded] = new PlayerGroundedStates(context, this);
            _states[PlayerStates.Attack] = new PlayerAttackState(context, this);
            _states[PlayerStates.Hurt] = new PlayerHurtState(context, this);
            _states[PlayerStates.Roll] = new PlayerRollState(context, this);


            _states[PlayerStates.Idle] = new IdleState(context, this);
            _states[PlayerStates.Walk] = new WalkState(context, this);


            _states[PlayerStates.AttackOne] = new AttackOne(context, this);
            _states[PlayerStates.AttackTwo] = new AttackTwo(context, this);
            _states[PlayerStates.AttackThree] = new AttackThree(context, this);


        }

        public PlayerBaseState Grounded()
        {
            return _states[PlayerStates.Grounded];
        }

        public PlayerBaseState AttackState()
        {
            return _states[PlayerStates.Attack];
        }
        public PlayerBaseState IdleState()
        {
            return _states[PlayerStates.Idle];
        }

        public PlayerBaseState WalkState()
        {
            return _states[PlayerStates.Walk];
        }

        public PlayerBaseState AttackOne()
        {
            return _states[PlayerStates.AttackOne];
        }

        public PlayerBaseState HurtState()
        {
            return _states[PlayerStates.Hurt];
        }
        public PlayerBaseState RollState()
        {
            return _states[PlayerStates.Roll];
        }

        public PlayerBaseState AttackTwo()
        {
            return _states[PlayerStates.AttackTwo];
        }
        public PlayerBaseState AttackThree()
        {
            return _states[PlayerStates.AttackThree];
        }


    }
    }
