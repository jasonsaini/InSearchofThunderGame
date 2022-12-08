using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeEnemyController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private const float MAX_HEALTH = 100f;
    [SerializeField] public float health = 100f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = .5f;
    public LayerMask enemyLayers;

    private bool dead = false;

    public Healthbar hb; 
    public Transform playerLocation;
    public PlayerController Thor;
    public UnityEngine.AI.NavMeshAgent enemy;
    public Vector3 lastEnemyvelocity;

    [SerializeField] public float attackCooldown = 0.5f;
    private bool canAttack = true;

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
        if (!dead && !Thor.dead)
        {
            Look();
            Chase();
            DeclanAttack();
            healthbar.updateHealthBar(MAX_HEALTH, health);
        }

        hb.updateHealthBar(health, MAX_HEALTH);
        
    }

    void FixedUpdate()
    {


    }
    void Chase()
    {
        //animator.SetTrigger("Attacking", false);
        if (!Thor.dead)
        {
            animator.SetBool("Moving", true);
            enemy.SetDestination(playerLocation.position);
        }
        
    }

    void DeclanAttack()
    {
        if (enemy.remainingDistance < enemy.stoppingDistance) {
            if (canAttack) {
                // stop running attacking
                lastEnemyvelocity = enemy.velocity;
                enemy.velocity = Vector3.zero;
                // play attack animation
                animator.SetTrigger("Attack");
                animator.SetBool("Moving", false);
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider enemy in hitEnemies)
                    enemy.GetComponent<PlayerController>().TakeDamage(damage);

                StartCoroutine(ResetAttackCooldown());
            }

        }
        else {
            animator.enabled = true;
            enemy.velocity = lastEnemyvelocity;
        }
    }

    IEnumerator ResetAttackCooldown() {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void Look()
    {
        if(!Thor.dead)
        {
            this.transform.LookAt(playerLocation);
        }
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("HitReacting");

        if (health <= 0) {

            dead = true;
            animator.SetBool("Attacking", false);
            animator.SetBool("Moving", false);
            animator.SetTrigger("Dead");

        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
