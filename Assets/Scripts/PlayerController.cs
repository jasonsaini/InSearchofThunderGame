using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private BoxCollider playerCollider;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private float dashSpeed = 10;

    // Added by Declan in case we want to create snappier movement, by snappng movement controller, and slowly turning animation
    // [SerializeField] private Transform _model;

    private Vector3 _input;

    private void Start()
    {
        //Physics.IgnoreCollision(playerCollider, GetComponent<Collider>());

        // Automatically assigns the Rigid Body and Collider as those of the GameObject
        _rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        GatherInput();
        Look();
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
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        transform.rotation = rot;
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);

    }
    
    
}


public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
