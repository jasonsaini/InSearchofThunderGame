using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{
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
            
            Instantiate(projectile, projectilePos, Quaternion.identity);
            shotInterval = startShotInterval;
        }
        else
        {
            shotInterval -= Time.deltaTime;
        }
    }
}
