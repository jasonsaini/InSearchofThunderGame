using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CapsuleCollider playerCollider;
    [SerializeField] private float _speed = 12.5f;
    [SerializeField] private float _turnSpeed = 360f;
    [SerializeField] private float dashSpeed = 275f;
    // Player attributes
    [SerializeField] private float Health = 100f;
    [SerializeField] private float Damage = 20f;
    private Vector3 _input;
    bool moving;
    Animator animator;
    private void Start()
    {
        moving = false;
        //Physics.IgnoreCollision(playerCollider, GetComponent<Collider>());
        //animator = this.
        _rb.mass = 5f;
        _rb.drag = 11f;
        _rb.angularDrag = 2f;
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
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        moving = true;
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
        moving = false;
    }


}


public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
