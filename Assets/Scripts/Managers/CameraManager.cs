using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HackSlash
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] Transform playerTransform;


        
        private void LateUpdate()
        {
            

            Vector3 CameraPosition = transform.position;

            Vector3 PlayerPositon = playerTransform.position;

            PlayerPositon.x = Mathf.Clamp(playerTransform.position.x, 0, 50f);

            CameraPosition.x = Mathf.Max(0, PlayerPositon.x); // as Mario goes right it increases the value of X and Mathf Max only makes sures the x value dont decrease as mario tries to go left
            transform.position = CameraPosition;
        }

        private void CameraShake()
        {

           
        }
    }
}
