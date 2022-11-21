using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject bigBad;
    public GameObject Thor;
    public float pullSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Thor = GameObject.Find("Thor");
        bigBad = GameObject.Find("BigBad");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

            /*
            bigBad.GetComponent<BigBad>().execution = true;
            Thor.GetComponent<PlayerController>().bigBadKill = true;
            */
            Thor.GetComponent<PlayerController>().health = 0;
        }
    }

}
