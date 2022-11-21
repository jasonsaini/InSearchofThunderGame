using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public GameObject Thor;
    public float pullSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Thor = GameObject.Find("Thor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Thor in magnet!");
            //other.transform.Translate(Time.deltaTime * pullSpeed * (this.transform.position - Thor.transform.position).normalized);
            Vector3.Lerp(this.transform.position, other.transform.position, .8);
        }
    }

}
