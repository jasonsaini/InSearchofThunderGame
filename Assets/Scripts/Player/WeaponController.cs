using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class WeaponController : MonoBehaviour
{
    public PlayerController Thor;
    public MeshRenderer enemyMesh;
    public float flashTime = 2f;
    Color origColor;
    // Start is called before the first frame update
    void Start()
    {
        
        Thor = GameObject.Find("Thor").GetComponent<PlayerController>();
        enemyMesh = GameObject.Find("SkellyBoi").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (Thor.attacking)
        {


            if (other.CompareTag("MeleeEnemy"))
            {
               
            }
            else if (other.CompareTag("RangedEnemy"))
            {
                              
            }
        }
    }


}
