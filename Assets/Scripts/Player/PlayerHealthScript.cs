using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HackSlash.Player
{
    public class PlayerHealthScript : MonoBehaviour
    {

        [SerializeField] private PlayerStats stats;
        [SerializeField] private Image healthbar;

        public static PlayerHurt playerHurt;


        public float MaxHealth => stats.MaxHealth;
        public float RuntimeHealth;

        private void OnEnable()
        {
            RuntimeHealth = MaxHealth;
            
        }


        public void Update()
        {
            RuntimeHealth = Mathf.Clamp(RuntimeHealth, 0, MaxHealth);

       
   
        }

     

        public void TakeDamage(int _damage)
        {
            
            RuntimeHealth -= _damage;
            playerHurt?.Invoke();
            Debug.Log(_damage);

            #region healthbar
            float healthfill = healthbar.fillAmount;

            float ratio = RuntimeHealth / MaxHealth;

            if (healthfill > ratio)
            {



                healthbar.fillAmount = ratio;



            }
            #endregion




        }




    }

    public delegate void PlayerHurt();
}
