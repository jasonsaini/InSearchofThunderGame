using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeEnemyController : Enemy
{
    public Animator animator;
    public Transform playerLocation;
    public PlayerController Thor;
    public UnityEngine.AI.NavMeshAgent enemy;
    public Vector3 lastEnemyvelocity;

   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        // grab player script
        Thor = (PlayerController)(FindObjectOfType(typeof(PlayerController)));
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Chase();
        Attack();
    }

    void FixedUpdate()
    {

       

    }
    void Chase()
    {
        animator.SetBool("Attacking", false);
        animator.SetBool("Moving", true);
        enemy.SetDestination(playerLocation.position);
    }
    void Attack()
    {
        
        if (enemy.remainingDistance < enemy.stoppingDistance)
        {
            // stop running attacking
            lastEnemyvelocity = enemy.velocity;
            enemy.velocity = Vector3.zero;
            // play attack animation
            animator.SetBool("Attacking", true);
            animator.SetBool("Moving", false);
            // deal damage to player
            //Thor.health -= 1;
        }
        else
        {
            animator.enabled = true;
            enemy.velocity = lastEnemyvelocity;
        }
    }
    void Look()
    {
        this.transform.LookAt(playerLocation);
    }
}