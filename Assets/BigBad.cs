using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBad : MonoBehaviour
{
    public Animator animator;
    private GameObject Thor;
    private Vector3 playerLocation;
    GameObject bigBad;
    public UnityEngine.AI.NavMeshAgent enemy;
    public bool trapped = false, execution = false;
    // Start is called before the first frame update
    void Start()
    {
        Thor = GameObject.Find("Thor");
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        if (trapped)
        {
            enemy.isStopped = true;
            animator.SetBool("Moving", false);
        }
        if(execution)
        {
            enemy.isStopped = true;
            animator.SetBool("Moving", false);
            animator.SetTrigger("Deathcast");
        }    
    }
    void Chase()
    {
        if(!trapped)
        {
            enemy.isStopped = false;
            animator.SetBool("Moving", true);
            enemy.SetDestination(Thor.transform.position);
        }

   
    }



    private void SetTrap()
    {
        trapped = true;
    }


}
