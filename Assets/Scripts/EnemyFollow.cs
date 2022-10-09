using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollow : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public UnityEngine.AI.NavMeshAgent enemy;
    public Vector3 lastEnemyvelocity;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        
    }

    void FixedUpdate()
    {
        Chase();
        Attack();

    }
    void Chase()
    {
        enemy.SetDestination(player.position);
    }
    void Attack()
    {
        
        if (enemy.remainingDistance < enemy.stoppingDistance)
        {
            // stop running attacking
            lastEnemyvelocity = enemy.velocity;
            enemy.velocity = Vector3.zero;
            // play attack animation
            animator.SetTrigger("Attack");
            // deal damage to player
        }
        else
        {
            animator.enabled = true;
            enemy.velocity = lastEnemyvelocity;
        }
    }
    void Look()
    {
        this.transform.LookAt(player);
    }
}
