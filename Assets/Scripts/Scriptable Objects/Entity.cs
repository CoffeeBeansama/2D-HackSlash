using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash
{
    public abstract class Entity : ScriptableObject
    {


       
        public int MaxHealth;
        public int Damage;

        [Range(0f, 10f)]public float AttackReach;
        [Range(0f, 20f)]public float MovementSpeed;
        [Range(0f,10f)]public float AttackRadius;
    }
}
