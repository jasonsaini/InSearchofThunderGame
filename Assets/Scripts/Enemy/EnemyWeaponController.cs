using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    private PlayerController playerAttributes;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        playerAttributes = GameObject.Find("Thor").GetComponent<PlayerController>();

         
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerAttributes.health -= 30;
        }
    }
}
