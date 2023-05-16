using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackSlash.Player
{
    public class SwordCollider : MonoBehaviour
    {
        new BoxCollider2D collider2D;
        

        private void Start()
        {
            collider2D = GetComponent<BoxCollider2D>();
            collider2D.enabled = false;

            PlayerController.activateSword += ActivateSelf;
            PlayerController.inactivateSword += InActivateSelf;
            

          
        }

        private void ActivateSelf()
        {
            collider2D.enabled = true;
           
        }



        private void InActivateSelf()
        {
            collider2D.enabled = false; 
            

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemies"))
            {
                Debug.Log("Enemy Detected");
            }
        }


       



        private void OnDisable()
        {
            PlayerController.activateSword -= ActivateSelf;
            PlayerController.inactivateSword -= InActivateSelf;
        }
    }
}
