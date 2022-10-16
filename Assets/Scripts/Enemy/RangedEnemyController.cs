using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] public float Health = 100f;
    [SerializeField] private float Damage = 20f;
    private bool dead = false;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float shotInterval;
    public float startShotInterval;

    public GameObject projectile;
     public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (Health <= 0)
        {

            animator.SetTrigger("Dead");
            dead = true;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        Vector3 projectilePos;
        if (shotInterval <= 0)
        {
            projectilePos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            transform.LookAt(player);
            Instantiate(projectile, projectilePos, transform.rotation);
            shotInterval = startShotInterval;
        }
        else
        {
            shotInterval -= Time.deltaTime;
        }
    }
}
