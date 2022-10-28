using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangInstance : MonoBehaviour { 

    bool go;
    public float speed;
    public float throwDistance = 10f;
    GameObject player;
    GameObject hammer;
    public GameObject hammerToThrow;
    Vector3 target;
    

    // alright so this shit doesn't work
    // send hammer at some distance 
    // set rotation

    // Start is called before the first frame update
    void Start()
    {
        go = false;
        player = GameObject.Find("Thor");
        hammer = GameObject.Find("Mjolnir");
        
        hammer.GetComponent<MeshRenderer>().enabled = false;
        hammerToThrow.GetComponent<MeshRenderer>().enabled = true;
        hammerToThrow = GameObject.Find("MjolnirBackup");
        target = new Vector3(player.transform.position.x,player.transform.position.y ,player.transform.position.z) + player.transform.forward * throwDistance;

    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position == target)
        {
            Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(transform.position == player.transform.position)
        {
            hammer.GetComponent<MeshRenderer>().enabled = true;
            hammerToThrow.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // finish enemy damage
    }
}
