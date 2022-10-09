using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    public Transform playerLocation;
    public PlayerController Thor;
    public UnityEngine.AI.NavMeshAgent enemy;
    public Vector3 lastEnemyvelocity;
    // Start is called before the first frame update
    void Start()
    {
       // grab player script
        Thor = (PlayerController)(FindObjectOfType(typeof(PlayerController)));
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Chase();
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

        if (enemy.remainingDistance < enemy.stoppingDistance)
        {
            // stop running attacking
            lastEnemyvelocity = enemy.velocity;
            enemy.velocity = Vector3.zero;
            // play attack animation
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
}
