using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HackSlash.Enemies
{
    public class EnemyHealthScript : MonoBehaviour , IEnemy
    {

        public int CurrentHitpoints;
        public TextMeshProUGUI DamageIndicator;
        public static HurtSound hurtSound;
        public static EnemyDeath enemyDeath;


        public bool KnockedBacked = false;
        public bool EnemyDead = false;
        public EnemyData Stats;
        new Rigidbody2D rigidbody2D;


    

        Transform player;
        
     

        private void Start()
        {

            player = GameObject.FindGameObjectWithTag("Player").transform;
            rigidbody2D = GetComponent<Rigidbody2D>();
          
       
           
        }

        private void OnEnable() => CurrentHitpoints = Stats.MaxHealth;
      


        public void TakeDamage(int _damageTaken,float _knockbackDistance)
        {
        
            CurrentHitpoints -= _damageTaken;
            KnockedBacked = true;



            if (CurrentHitpoints <= 0)
            {
                Death();
            }
            

           
            
        }

       
      

      

        private void Death()
        {
            EnemyDead = true;
         
        }

        public void DisableSelf()
        {
            gameObject.SetActive(false);
            ObjectSpawner.EnemyDeathCount += 1;
            enemyDeath?.Invoke();

        }
    }

    public delegate void EnemyDeath();
    

}
