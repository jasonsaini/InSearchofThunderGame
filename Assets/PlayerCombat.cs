using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float lightAttackRange = 0.5f;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lightAttack();
        }     
    }

    void lightAttack(){
        // Play an attack animation
        animator.SetTrigger("isLightAttack");
        print("lightAttack");

        // Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, lightAttackRange, enemyLayers);

        // Damage enemies detected
        foreach(Collider enemy in hitEnemies){
            print("We hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected(){
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, lightAttackRange);
    }

}
