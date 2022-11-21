using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    private GameObject Thor;
    private GameObject thorHand;
    private GameObject throwPlaceholder;
    private GameObject recallPlaceholder;

    private Rigidbody rb;

    public float flightSpeed = 10f;
    public float returnDistance = 5f;
    public float catchDistance = 1f;
    public bool away;
    public float throwPower = 50f;

    public enum HammerState { Static, Thrown, Travelling, Returning }
    public HammerState hammerState;

    public float startTime;
    public float journeyLength;
    private Vector3 startPos;
    private Vector3 endPos;


    // Start is called before the first frame update
    void Start()
    {
        Thor = GameObject.Find("Thor");
        thorHand = GameObject.Find("Thor_Hand_R");
        recallPlaceholder = GameObject.Find("RecallPlaceHolder");
        throwPlaceholder = GameObject.Find("ThrowPlaceHolder");
        away = false;

    }

    // Update is called once per frame
    void Update()
    { 
        // return to thor if retreat distance
        if (Vector3.Distance(Thor.transform.position, transform.position) >= returnDistance) {

            rb.velocity = Vector3.zero;
            
        }
        if (transform.parent == thorHand.transform)
        {
            hammerState = HammerState.Static;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1) && hammerState == HammerState.Static)
        {
            hammerState = HammerState.Thrown;
        }
        /*
        if(Input.GetMouseButton(1) && hammerState != HammerState.Static)
        {
            // play alternate attack animation
        } 
        */
        if (Input.GetMouseButton(2))
        {
            hammerState = HammerState.Returning;
        }
        if(hammerState == HammerState.Thrown)
        {
            HammerThrow();
        }
        if (hammerState == HammerState.Returning)
        {
            HammerReturn2();
           
        }
    }

    void HammerThrow()
    {
        this.gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.transform.parent = null;
        hammerState = HammerState.Travelling;
        rb.isKinematic = false;
        rb.useGravity = false;
        transform.rotation = throwPlaceholder.transform.rotation;
        rb.AddForce(((Thor.transform.forward) * throwPower), ForceMode.Impulse);
    }
    
    void HammerReturn()
    {
       
        //transform.position = Vector3.MoveTowards(transform.position, recallPlaceholder.transform.position, flightSpeed);
        RecalledHammer();
        hammerState = HammerState.Static;
    }
    void HammerReturn2()
    {

       
            RecalledHammer();
            hammerState = HammerState.Static;
            Debug.Log("Hammer state is set to static!");

    }
    void RecalledHammer()
    {
        
        transform.position = recallPlaceholder.transform.position;
        transform.rotation = recallPlaceholder.transform.rotation;
        transform.SetParent(thorHand.transform);
        transform.parent = thorHand.transform;
        Destroy(rb);
        hammerState = HammerState.Static;

    }

    
}
