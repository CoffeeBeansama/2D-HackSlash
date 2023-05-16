using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Controls
{
    public static class PlayerInput
    {


        private static KeyCode leftButton = KeyCode.A;
        private static KeyCode rightButton = KeyCode.D;
        private static KeyCode AttackOneButton = KeyCode.Q;
        private static KeyCode RollButton = KeyCode.E;

        public static PlayerGoingLeft playerGoingLeft;
        public static PlayerGoingRight playerGoingRight;

        public static bool PressingAttackKeyButton => Input.GetKey(AttackOneButton);
        public static bool PressingAttackKeyButtonDown => Input.GetKeyDown(AttackOneButton);
        public static bool PressingLeft => Input.GetKey(leftButton);
        public static bool PressingRight => Input.GetKey(rightButton);
        public static bool PressingRoll => Input.GetKey(RollButton);







    }

    public delegate void PlayerGoingLeft();
    public delegate void PlayerGoingRight();
}
