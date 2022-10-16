using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour { 

    bool go;

    GameObject player;
    GameObject hammer;

    Vector3 locationInFrontOfPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        go = false;
        player = GameObject.Find("Thor");
        hammer = GameObject.Find("Mjolnir");

        hammer.GetComponent<MeshRenderer>().enabled = false;

        locationInFrontOfPlayer = new Vector3(player.transform.position.x,player.transform.position.y + 1 ,player.transform.position.z) + player.transform.forward * 10f;

        StartCoroutine(BoomerangThrow());
    }

    IEnumerator BoomerangThrow()
    {
        go = true;
        yield return new WaitForSeconds(1.0f);
        go = false;
    }
    // Update is called once per frame
    void Update()
    {
      if (go)
      {
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 40); //Change The Position To The Location In Front Of The Player
        }
      if(!go)
      {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 40); //Return To Player
      }
      if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5)
      {
            //Once It Is Close To The Player, Make The Player's Normal Weapon Visible, and Destroy The Clone
          hammer.GetComponent<MeshRenderer>().enabled = true;
          Destroy(this.gameObject);
      }
    }
}
