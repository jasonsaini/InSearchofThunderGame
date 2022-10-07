using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CapsuleCollider playerCollider;
    [SerializeField] private float _runSpeed = 12.5f;
    [SerializeField] private float _walkSpeed = 8.5f;
    [SerializeField] private float _idleSpeed = 0f;
    
    [SerializeField] private float _turnSpeed = 360f;
    [SerializeField] private float dashSpeed = 275f;
    // Player attributes
    [SerializeField] private float Health = 100f;
    [SerializeField] private float Damage = 20f;
    private Vector3 _input;
    bool moving = false;
    float moveSpeed;
    Animator animator;
    private void Start()
    {
       
        //Physics.IgnoreCollision(playerCollider, GetComponent<Collider>());
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("moving", 0);
    }


    private void Update()
    {
        GatherInput();
        Look();
        //animator.SetBool("isWalking", moving);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            _rb.freezeRotation = true;
            _rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
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

    private void Look()
    {
        if (_input == Vector3.zero)
        {
            animator.SetFloat("moving", 0);
            return;
        }
        else animator.SetFloat("moving", 1);
        

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _runSpeed * Time.deltaTime);
        
    }


}


public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
