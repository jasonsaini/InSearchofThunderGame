using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeEnemyController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private const float MAX_HEALTH = 100f;
    [SerializeField] public float health = 100f;
    [SerializeField] private float damage = 20f;
    private bool dead = false;

    public Healthbar hb; 
    public Transform playerLocation;
    public PlayerController Thor;
    public UnityEngine.AI.NavMeshAgent enemy;
    public Vector3 lastEnemyvelocity;

    [SerializeField] private Healthbar healthbar;


    // Start is called before the first frame update
    void Start()
    {
        // grab player script
        Thor = GameObject.Find("Thor").GetComponent<PlayerController>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            Look();
            Chase();
            Attack();
            healthbar.updateHealthBar(MAX_HEALTH, health);
        }

        hb.updateHealthBar(health, MAX_HEALTH);
        
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
    // Uncomment, Declan
    //void onTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Mjolnir")
    //    {
    //        health -= 25;
    //        animator.SetTrigger("HitReacting");
    //    }
    //}

    public void TakeDamage(float damage){
        health -= damage;
        animator.SetTrigger("HitReacting");

        if (health <= 0) {

            dead = true;
            animator.SetBool("Attacking", false);
            animator.SetBool("Moving", false);
            animator.SetTrigger("Dead");

        }
    }

}
