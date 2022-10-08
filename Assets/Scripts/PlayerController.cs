using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // Object Declarations
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CapsuleCollider playerCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject LightningDashFX;

    // Movement Attributes
    [SerializeField] private float _runSpeed = 12.5f;
    [SerializeField] private float _dashSpeedMax = 2f;
    [SerializeField] private float dashTimerMax = .2f;
    [SerializeField] private float dashTimeoutMax = .8f;
    //[SerializeField] private float _turnSpeed = 360f;

    // Player Attributes
    [SerializeField] private float Health = 100f;
    [SerializeField] private float Damage = 20f;

    // Temp. Variables
    private Vector3 _input;
    bool moving = false;
    float moveSpeed;

    private float dashTimer;
    private bool canDash = true;
    private float _dashSpeed = 1f;
    private float dashTimeout;

    private void Start()
    {
        // Fetch Objects
        animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        GatherInput();
        Look();
        Dash();

        // Attack; Left-Click
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Slash");
        }

        // Attack; Right-Click
        if (Input.GetMouseButtonDown(1)) {
            animator.SetTrigger("Slash");
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _input != Vector3.zero && canDash == true) {
            _rb.freezeRotation = true;
            canDash = false;
            dashTimer = dashTimerMax;
            dashTimeout = dashTimeoutMax;
            _dashSpeed = _dashSpeedMax;
            animator.SetTrigger("Dash");
            LightningDashFX.SetActive(true);
        }

        if (canDash == false) {
            if (dashTimer > 0f) {
                dashTimer -= Time.deltaTime;
            }
            else {
                dashTimer = 0f;
                _dashSpeed = 1f;
            }

            if (dashTimeout >= 0f) {
                dashTimeout -= Time.deltaTime;
            }
            else {
                LightningDashFX.SetActive(false);
                dashTimeout = 0f;
                canDash = true;
            }
        }
    }

    private void Look()
    {
        //if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        if (_input == Vector3.zero)
        {
            //animator.SetFloat("Blend", 0);
            animator.SetBool("Walking", false);
            return;
        }
        else animator.SetBool("Walking", true);
        

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        transform.rotation = rot;
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _runSpeed * _dashSpeed * Time.deltaTime);   
    }
}


public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
