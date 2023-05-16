using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Controls;
using HackSlash.Enemies;

namespace HackSlash.Player
{
    
    public class PlayerController : MonoBehaviour
    {

        public static ActivateSwordCollider activateSword;
        public static InactivateSwordCollider inactivateSword;

        public PlayerStats Stats;
        public Transform SwordPoint;
        public LayerMask EnemyMask;

        

        
        private bool Attacking = false;
        private bool Walking = false;
        private bool AttackOneEnd = false;


        public float KnockbackForce = 2f;

        private int idleHash, walkHash, attackOneHash;

        Vector3 _playerXscale;

        new Rigidbody2D rigidbody;
        SpriteRenderer spriteRenderer;
        public Animator animator;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

            _playerXscale = transform.localScale;

            walkHash = Animator.StringToHash("PlayerWalking");
            idleHash = Animator.StringToHash("PlayerIdle");
            attackOneHash = Animator.StringToHash("PlayerAttack");

        }

       
        private void NegativePlayerXscale()
        {

        }

        private void FixedUpdate()
        {
            

            HandleHorizontalMovement();
            HandleAnimation();
        }

        private void HandleAnimation()
        {
            if (Walking)
            {
                animator.SetBool(walkHash, true);
            }
            else
            {
                animator.SetBool(walkHash, false);
            }

            if (PlayerInput.PressingAttackKeyButton)
            {
                Attacking = true;
                animator.SetBool(attackOneHash, true);

         
                
            }
        }

       

        private void HandleHorizontalMovement()
        {
            if (!Attacking)
            {
               

                if (PlayerInput.PressingLeft)
                {
                    Walking = true;
                    rigidbody.position += Vector2.left * Stats.MovementSpeed * Time.fixedDeltaTime;

                    _playerXscale.x = -1;
                    

                }
                else if (PlayerInput.PressingRight)
                {
                    rigidbody.position += Vector2.right * Stats.MovementSpeed * Time.fixedDeltaTime;
                    spriteRenderer.flipX = false;
                    Walking = true;

                    _playerXscale.x = 1;
                  

                }
                else
                {
                    Walking = false;
                }


                transform.localScale = _playerXscale;
            }
        }


        #region Attacking
        public void HitEnemies()
        { 
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(SwordPoint.position, Stats.AttackRadius, EnemyMask);


            foreach (Collider2D enemy in enemiesHit)
            {
                EnemyHealthScript enemyHealthScript = enemy.GetComponent<EnemyHealthScript>();
              

                enemyHealthScript.TakeDamage(Stats.Damage, KnockbackForce);



             
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(SwordPoint.position, Stats.AttackRadius);
        }

        #endregion

        #region PlayerAnimationEvents

        public void EnableSword()
        {
            activateSword?.Invoke();
            Debug.Log("Activate");
        }

        public void DisableSword()
        {
            inactivateSword?.Invoke();
      
        }
        public void AttackOneEvent()
        {
            Attacking = false;
            animator.SetBool(attackOneHash, false);
        }

        #endregion

       
    }
    public delegate void ActivateSwordCollider();
    public delegate void InactivateSwordCollider();
}
