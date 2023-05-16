using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HackSlash.Player;


namespace HackSlash.Enemies
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(EnemyHealthScript))]
    public class EnemyStateManager : MonoBehaviour
    {

        public Transform AttackPoint;
        public LayerMask PlayerLayerMask;


        public EnemyData Stats;
        public bool KnockedBacked = false;
       
        float KnockbackTimer = 1f;

        [HideInInspector] public bool allowedToMove;

        [HideInInspector] public int walkHash, attackHash,hurtHash, deathHash;
        [HideInInspector] public bool PlayerOnAttackRange;
        [HideInInspector] public Transform target;
        [HideInInspector] public EnemyHealthScript healthScript;
        [HideInInspector] public Animator animator;
        [HideInInspector] public SpriteRenderer spriteRenderer;

        [HideInInspector] public new Rigidbody2D rigidbody2D;

     
        EnemyBaseState currentstate;


        public EnemyChaseState chasestate = new EnemyChaseState();
        public EnemyHurtState hurtstate = new EnemyHurtState();
        public EnemyAttackState attackstate = new EnemyAttackState();
        public EnemyDeathState deathstate = new EnemyDeathState();




        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            healthScript = GetComponent<EnemyHealthScript>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
            spriteRenderer = GetComponent<SpriteRenderer>();


          

            walkHash = Animator.StringToHash(Stats.WalkHash);
            attackHash = Animator.StringToHash(Stats.AttackHash);
            deathHash = Animator.StringToHash(Stats.DeathHash);
            hurtHash = Animator.StringToHash(Stats.HurtHash);

        }
     

        private void OnEnable() => OnRevive();



        public void SwitchState(EnemyBaseState state)
        {
            currentstate = state;
            state.EnterState(this);
        }


      


        private void OnRevive()
        {

            

            healthScript.EnemyDead = false;
            currentstate = chasestate;
            currentstate.EnterState(this);
            allowedToMove = true;
      
        }



        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, Stats.AttackReach);
            Gizmos.DrawWireSphere(AttackPoint.position, Stats.AttackRadius);

        }


        private void FixedUpdate()
        {
         

            currentstate.UpdateState(this);

        }

 

        public void HitPlayer()
        {
            Collider2D[] playerHit = Physics2D.OverlapCircleAll(AttackPoint.position, Stats.AttackRadius, PlayerLayerMask);

            foreach (Collider2D player in playerHit)
            {
                PlayerHealthScript playerHealth = player.GetComponent<PlayerHealthScript>();


                playerHealth?.TakeDamage(Stats.Damage);
            }
        }

        public void HurtFinished()
        {


            SwitchState(chasestate);
                
            

        }

        public void AllowedToMove()
        {
            allowedToMove = true;
        }

      

    }

    
}
