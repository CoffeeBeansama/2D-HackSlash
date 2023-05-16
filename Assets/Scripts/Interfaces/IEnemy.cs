using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Enemies
{
    public interface IEnemy 
    {

        public void TakeDamage(int _damage, float _knockbackDistance);
    }
}
