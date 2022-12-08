using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private const float MAX_HEALTH = 100f;
    [SerializeField] private float health = 100f;
    [SerializeField] private Healthbar hb;
    bool melee;
    public bool dead = false;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            dead = true;
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        animator.SetTrigger("HitReacting");

        if (health <= 0) {
            dead = true;
            animator.SetBool("Attacking", false);
            animator.SetBool("Moving", false);
            animator.SetTrigger("Dead");
        }

        hb.updateHealthBar(health, MAX_HEALTH);
    }

}
