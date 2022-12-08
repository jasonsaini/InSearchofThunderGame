using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    //[SerializeField] private Animator animator;
    [SerializeField] public float Health = 100f;
    public float MAX_HEALTH = 100f;
    
    [SerializeField] public float Damage = 10f;
    private bool dead = false;
    private bool stopped = false;
    public float speed;

    public float stoppingDistance;
    public float retreatDistance;

    public Healthbar hb;
    
    public float shotInterval;
    public float startShotInterval;
    public PlayerController playerController;
    public GameObject projectile;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
        //animator = GetComponentInChildren<Animator>(); // Where is this???
        playerController = GameObject.Find("Thor").GetComponent<PlayerController>();
        playerTransform = GameObject.Find("Thor").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (Health <= 0)
        {
            dead = true;
        }
        transform.LookAt(playerTransform);
        if(!dead && !playerController.dead)
        {
            if (!stopped)
            {
                if (Vector3.Distance(transform.position, playerTransform.position) > stoppingDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

                }
                else if (Vector3.Distance(transform.position, playerTransform.position) < stoppingDistance && Vector3.Distance(transform.position, playerTransform.position) > retreatDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);
                }
                else if (Vector3.Distance(transform.position, playerTransform.position) < retreatDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);

                }
                else
                {
                    stopped = true;
                }
            }
        }


        if (!dead && !playerController.dead)
        {

            Vector3 projectilePos;
            if (shotInterval <= 0)
            {
                projectilePos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                transform.LookAt(playerTransform);
                Instantiate(projectile, projectilePos, transform.rotation);
                shotInterval = startShotInterval;
            }
            else
            {
                shotInterval -= Time.deltaTime;
            }
        }
        }


        public void TakeDamage(float damage) {
        Health -= damage;
        //animator.SetTrigger("HitReacting");
        hb.updateHealthBar(MAX_HEALTH, Health);
        if (Health <= 0) {
            dead = true;
        }
        if(dead)
        {
            Destroy(this);
        }
    }
}
