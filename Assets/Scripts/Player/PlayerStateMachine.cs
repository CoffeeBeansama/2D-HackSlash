using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Enemies;
using HackSlash.Controls;

namespace HackSlash.Player.StateMachine
{
    public class PlayerStateMachine : MonoBehaviour
    {


        public static ActivateSwordCollider activateSword;
        public static InactivateSwordCollider inactivateSword;
        public static ShowDamage DisplayDamage;

        public PlayerStats Stats;
        public Transform AttackOnePoint;
        public Transform AttackTwoPoint;
        public LayerMask EnemyMask;
        


        public AudioClip AttackOneSfx;

        public float KnockbackForce = 2f;




        [HideInInspector] public Vector3 _playerXscale;
        

        [HideInInspector] public new Rigidbody2D rigidbody;
        [HideInInspector] public SpriteRenderer spriteRenderer;
        [HideInInspector] public Animator animator;

        [HideInInspector] public bool Attacking = false;
        [HideInInspector] public bool Rolling = false;

        [HideInInspector] public bool Damaged = false;

        
        private bool Walking = false;


        [HideInInspector] public int AttackClicks = 0;
        private int MaxAttackClicks = 3;

        [HideInInspector] public int idleHash => Animator.StringToHash("PlayerIdle");
        [HideInInspector] public int walkHash => Animator.StringToHash("PlayerWalking");
        [HideInInspector] public int HurtHash => Animator.StringToHash("PlayerHurt");
        [HideInInspector] public int RollHash => Animator.StringToHash("PlayerRoll");
        [HideInInspector] public int attackOneHash => Animator.StringToHash("PlayerAttackOne");
        [HideInInspector] public int attackTwoHash => Animator.StringToHash("PlayerAttackTwo");

        [HideInInspector] public int attackThreeHash => Animator.StringToHash("PlayerAttackThree");

        PlayerBaseState currentState;
        PlayerStateCache states;
        public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; } }

        [HideInInspector] public bool CanContinueCombo = false;
        [HideInInspector] public bool EndOfCombo = false;
        [HideInInspector] public bool EndOfAttackOne = false;
        [HideInInspector] public bool EndOfComboTwo = false;

        private void Awake()
        {

            rigidbody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

            states = new PlayerStateCache(this);
            currentState = states.Grounded();
            currentState.EnterState();

           

            CanContinueCombo = false;


        _playerXscale = transform.localScale;

            _playerXscale.x = 1;
        }

        private void OnEnable() => PlayerHealthScript.playerHurt += PlayerHurt;
        private void OnDisable() => PlayerHealthScript.playerHurt -= PlayerHurt;


        public void PlayerHurt()
        {
            Damaged = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(AttackTwoPoint.position, Stats.AttackTwoRadius);
            Gizmos.DrawWireSphere(AttackOnePoint.position, Stats.AttackOneRadius);
        }

        private void Update()
        {
     
            AttackClicks = Mathf.Clamp(AttackClicks, 0, MaxAttackClicks);
          
            if (PlayerInput.PressingAttackKeyButtonDown)
            {

                AttackClicks += 1;
            }
        }


        private void FixedUpdate()
        {
            currentState.UpdateStates();
        }
        public void HitEnemiesOne()
        {
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(AttackOnePoint.position, Stats.AttackOneRadius, EnemyMask);

            DisplayDamage?.Invoke(Stats.Damage);

            foreach (Collider2D enemy in enemiesHit)
            {
               EnemyHealthScript enemyHealthScript = enemy.GetComponent<EnemyHealthScript>();
               HealthText healthText = enemy.GetComponentInChildren<HealthText>();
                
                
               healthText?.DisplayDamage(Stats.Damage);
               enemyHealthScript?.TakeDamage(Stats.Damage, KnockbackForce);




            }
        }

        public void HitEnemiesTwo()
        {
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(AttackTwoPoint.position, Stats.AttackTwoRadius, EnemyMask);

            DisplayDamage?.Invoke(Stats.Damage);

            foreach (Collider2D enemy in enemiesHit)
            {
                EnemyHealthScript enemyHealthScript = enemy.GetComponent<EnemyHealthScript>();
                HealthText healthText = enemy.GetComponentInChildren<HealthText>();


                healthText?.DisplayDamage(Stats.Damage);
                enemyHealthScript?.TakeDamage(Stats.Damage, KnockbackForce);




            }
        }
        #region PlayerAnimationEvents


        public void EndOfAttackTwo()
        {
            EndOfComboTwo = true;
        }

        public void AttackOneEnd()
        {
            EndOfAttackOne = true;
        }
        public void ReturnToIdleState()
        {
            Damaged = false;
        }

        public void RollingFinished()
        {
            Rolling = false;
        }

        public void ComboBuffer()
        {
            CanContinueCombo = true;
        }


        public void EndComboBuffer()
        {
            EndOfCombo = true;
            CanContinueCombo = false;
        }


        public void EnableSword()
        {
            activateSword?.Invoke();
            
        }

        public void DisableSword()
        {
            inactivateSword?.Invoke();

        }
        public void AttackEndEvent()
        {
            CanContinueCombo = false;
            Attacking = false;
          

        }
        #endregion

    }

    public delegate void ShowDamage(int amount);



}
