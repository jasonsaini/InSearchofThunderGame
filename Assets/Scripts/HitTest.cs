using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HitTest : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         anim = GameObject.Find("SkellyBoi").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("Attacking") == true)
        {
            GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Melee weapon enabled!");
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Melee weapon disabled!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.health -= 3;
        }
        
    }
}
