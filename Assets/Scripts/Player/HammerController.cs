using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    private GameObject Thor;
    private GameObject thorHand;

    private Rigidbody rb;

    public float returnSpeed;
    public float returnDistance = 5f;
    public float catchDistance = 1f;
    public bool away;
    // Start is called before the first frame update
    void Start()
    {
        Thor = GameObject.Find("Thor");
        thorHand = GameObject.Find("Thor_Hand_R");
        rb = GetComponent<Rigidbody>();
        away = false;

    }

    // Update is called once per frame
    void Update()
    {
        // return to thor if retreat distance
        if (Vector3.Distance(Thor.transform.position, transform.position) >= returnDistance) {

            rb.velocity = Vector3.zero;
            transform.LookAt(Thor.transform);
        }
        if(Vector3.Distance(Thor.transform.position, transform.position) > catchDistance)
        {
            away = true;
        }
    }

    /*
    private void HammerReturn()
    {
        while (Vector3.Distance(thorHand.transform.position, transform.position) > catchDistance)
        {
            Vector3.MoveTowards(transform.position, thorHand.transform.position, returnSpeed * Time.deltaTime);
        }

    }
    */
}
