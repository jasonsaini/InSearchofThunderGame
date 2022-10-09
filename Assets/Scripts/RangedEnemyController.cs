using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    public Transform playerLocation;
    public PlayerController Thor;
    public UnityEngine.AI.NavMeshAgent enemy;
    public Vector3 lastEnemyvelocity;
    public Vector3 distFromPlayer;
    private Animator animator;
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
        if (enemy.remainingDistance < 5f)
        {
            BackAway();
        }
     }

    void FixedUpdate()
    {
        


    }
    void Chase()
    {
      
       enemy.SetDestination(playerLocation.position);
    }
    void Attack()
    {

        if (enemy.remainingDistance >= enemy.stoppingDistance)
        {
            // play attack animation
            animator.SetTrigger("Attack");
            // deal damage to player
            //Thor.health -= 1;
        }
        else
        {
           enemy.velocity = lastEnemyvelocity;
        }
    }
    void Look()
    {
        this.transform.LookAt(playerLocation);
    }

    void BackAway()
    {
        //this.transform.Translate(-transform.forward * enemy.speed * Time.deltaTime);
    }
}
