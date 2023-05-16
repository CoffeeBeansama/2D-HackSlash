using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    public abstract class EnemyBaseState 
    {
        public abstract void EnterState(EnemyStateManager enemy);



        public abstract void UpdateState(EnemyStateManager enemy);

        public abstract void CheckSwitchState(EnemyStateManager enemy);

       
        

        
    }
}
