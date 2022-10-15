using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector3 target;
    private PlayerController playerAttributes;

    // Start is called before the first frame update
    void Start()
    {
        playerAttributes = GameObject.Find("Thor").GetComponent<PlayerController>();
        player = GameObject.Find("Thor").transform;
        target = new Vector3(player.position.x, player.position.y + 2, player.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position == target)
        {
            DestroyProjectile();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAttributes.health -= 30;
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}