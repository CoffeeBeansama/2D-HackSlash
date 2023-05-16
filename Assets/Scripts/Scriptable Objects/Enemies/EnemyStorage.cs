using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    [CreateAssetMenu(fileName = "EnemyStorage", menuName = "Storage/Enemy")]
    public class EnemyStorage : ScriptableObject
    {
        public GameObject[] Enemies;

        
    }
}
