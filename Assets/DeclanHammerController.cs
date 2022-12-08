using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclanHammerController : MonoBehaviour {
    [SerializeField]private GameObject Thor;
    private GameObject thorHand;
    private GameObject throwPlaceholder;
    private GameObject recallPlaceholder;
    private Rigidbody rb;
    [SerializeField] private float damage = 10f;
    [SerializeField] private MeshCollider mesh;

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

    AudioSource audioData;

    // Start is called before the first frame update
    void Start() {
        //Thor = GameObject.Find("Thor(1)"); // Declan, change back
        thorHand = GameObject.Find("Thor_Hand_R");
        recallPlaceholder = GameObject.Find("RecallPlaceHolder");
        throwPlaceholder = GameObject.Find("ThrowPlaceHolder");
        away = false;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        // return to thor if retreat distance
        if (Vector3.Distance(Thor.transform.position, transform.position) >= returnDistance) {

            rb.velocity = Vector3.zero;

        }
        //if (transform.parent == thorHand.transform) {
        //    hammerState = HammerState.Static;
        //}
    }

    void FixedUpdate() {
        if (Input.GetMouseButtonDown(1) && hammerState == HammerState.Static) {
            mesh.enabled = true;
            hammerState = HammerState.Thrown;
        }

        if (Input.GetMouseButton(2)) {
            hammerState = HammerState.Returning;
            mesh.enabled = false;
            HammerReturn2();
        }
        if (hammerState == HammerState.Thrown) {
            HammerThrow();
        }
        if (hammerState == HammerState.Returning) {
            
        }
    }

    void HammerThrow() {
        this.gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.transform.parent = null;
        hammerState = HammerState.Travelling;
        rb.isKinematic = false;
        rb.useGravity = false;
        transform.rotation = throwPlaceholder.transform.rotation;
        // add hammer throw sound effect
        rb.AddForce(((Thor.transform.forward) * throwPower), ForceMode.Impulse);
    }

    void HammerReturn() {

        //transform.position = Vector3.MoveTowards(transform.position, recallPlaceholder.transform.position, flightSpeed);
        RecalledHammer();
        hammerState = HammerState.Static;
        // TODO: play hammer return sound effect
    }
    void HammerReturn2() {


        RecalledHammer();
        hammerState = HammerState.Static;
        //Debug.Log("Hammer state is set to static!");
        audioData.Play(0);
    }
    void RecalledHammer() {

        // audioData.Play(0);
        transform.position = recallPlaceholder.transform.position;
        transform.rotation = recallPlaceholder.transform.rotation;
        transform.SetParent(thorHand.transform);
        transform.parent = thorHand.transform;
        Destroy(rb);
        hammerState = HammerState.Static;

    }

    private void OnTriggerEnter(Collider enemy) {
        if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            //Debug.Log("Hit: " + enemy.name);
            //other.gameObject.GetComponent<Animator>().SetTrigger("HitReacting");
            //other.gameObject.GetComponent<MeleeEnemyController>().health -= 30;
            if (enemy.GetComponent<MeleeEnemyController>() != null)
                enemy.GetComponent<MeleeEnemyController>().TakeDamage(damage);
            else if (enemy.GetComponent<RangedEnemyController>() != null)
                enemy.GetComponent<RangedEnemyController>().TakeDamage(damage);
        }
    }


}

