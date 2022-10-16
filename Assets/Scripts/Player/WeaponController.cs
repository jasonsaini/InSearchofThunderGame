using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class WeaponController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MeleeEnemy"))
        {
            MeleeEnemyController meleeEnemyAttributes = other.GetComponentInChildren<MeleeEnemyController>();
            meleeEnemyAttributes.Health -= 30;
        }
        else if(other.CompareTag("RangedEnemy"))
        {
            RangedEnemyController rangedEnemyAttributes = other.GetComponentInChildren<RangedEnemyController>();
            rangedEnemyAttributes.Health -= 30;
        }
    }
}
