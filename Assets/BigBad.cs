using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBad : MonoBehaviour
{
    public Animator animator;
    private GameObject Thor;
    private Vector3 playerLocation;
    public UnityEngine.AI.NavMeshAgent enemy;
    // Start is called before the first frame update
    void Start()
    {
        Thor = GameObject.Find("Thor");
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }
    void Chase()
    {
        animator.SetBool("Moving", true);
        enemy.SetDestination(Thor.transform.position);
    }
}
