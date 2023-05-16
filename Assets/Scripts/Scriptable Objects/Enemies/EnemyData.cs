using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData",menuName ="Entity/Enemy")]
    public class EnemyData : Entity
    {

       
        [HideInInspector]public string WalkHash = "EnemyWalk";
        [HideInInspector]public string AttackHash = "EnemyAttack";
        [HideInInspector]public string DeathHash = "EnemyDeath";
        [HideInInspector]public string HurtHash = "EnemyHurt";
        


    }
}
