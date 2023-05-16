using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Player
{

    [CreateAssetMenu(fileName = "PlayerInfo", menuName = "Entity/Player")]
    public class PlayerStats : Entity
    {
        [Range(0f,10f)] public float AttackOneRadius;
        [Range(0f, 10f)] public float AttackTwoRadius;

    }
}
