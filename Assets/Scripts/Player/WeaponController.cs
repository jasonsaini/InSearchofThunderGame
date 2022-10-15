using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class WeaponController : MonoBehaviour
{
    public Enemy enemyAttributes;
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
        if (other.CompareTag("Enemy"))
        {
            enemyAttributes.Health -= 50;
        }
    }
}
