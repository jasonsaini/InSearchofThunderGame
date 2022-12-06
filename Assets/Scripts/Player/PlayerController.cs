using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public const float MAX_HEALTH = 100f;
    // Object Declarations
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CapsuleCollider playerCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject LightningDashFX;
    public GameObject lightningTrap;
    BigBad bigBad;

    // Movement Attributes
    [SerializeField] private float _runSpeed = 12.5f;
    [SerializeField] private float _dashSpeedMax = 2f;
    [SerializeField] private float dashTimerMax = .2f;
    [SerializeField] private float dashTimeoutMax = .8f;

    // Player Attributes
    [SerializeField] public float health = MAX_HEALTH;
    [SerializeField] private float Damage = 20f;
    [SerializeField] public float attackCooldown = 1.0f;
    [SerializeField] private Healthbar healthbar;
    public bool attacking;
    private bool dead;
    // Temp. Variables
    private Vector3 _input;
    public bool moving = false;
    float moveSpeed;

    private float dashTimer;
    private bool canDash = true;
    private float _dashSpeed = 1f;
    private float dashTimeout;
    

    public bool canAttack = true, bigBadKill = false;
    
    // mjolnir variables
    public GameObject mjolnir;
    public HammerController hammerController;


    private void Start()
    {
        dead = false;
        // Fetch Objects
        animator = GetComponentInChildren<Animator>();
        healthbar = this.GetComponent<Healthbar>();
        mjolnir =  GameObject.Find("Mjolnir");
        hammerController = mjolnir.GetComponent<HammerController>();
        bigBad = GameObject.Find("BigBad").GetComponent<BigBad>();
    }

    private void Update()
    {
        
        
        moving = (_input == Vector3.zero);
        
        if (bigBadKill)
        {
            Execution();
        }
        if (!dead)
        {
            GatherInput();
            Look();
            Dash();
            Attack();    
        }
        if (health <= 0) { 
            {
                _rb.velocity = Vector3.zero;
                animator.SetTrigger("Dead");
            }
        }
        healthbar.updateHealthBar(MAX_HEALTH, health);
        if (animator.GetBool("Slash") == true)
        {
            GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Melee weapon enabled!");
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Melee weapon disabled!");
        }
    }

    public void Attack()
    {
        
        if (canAttack)
        {
            
            // Attack; Left-Click
            if (Input.GetMouseButtonDown(0))
            {
                attacking = true;
                animator.SetTrigger("Slash");
            }
            if (Input.GetMouseButton(2) &&  hammerController.hammerState == HammerController.HammerState.Static)
            {
                animator.SetTrigger("Special");
            }

        }
        StartCoroutine(ResetAttackCooldown());

    }
    
    IEnumerator ResetAttackCooldown()
    {
       
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        attacking = false;
        canAttack = true;
        
    }
    

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            dead = true;
        }
        if (!dead)
        {
            Move();
        }

        
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _input != Vector3.zero && canDash == true) {
            //_rb.freezeRotation = true;
            canDash = false;
            dashTimer = dashTimerMax;
            dashTimeout = dashTimeoutMax;
            _dashSpeed = _dashSpeedMax;
            LightningDashFX.SetActive(true);
            
            animator.SetTrigger("Dash");
            // instantiate lightning trap
            SetTrap();
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
        //transform.rotation = rot;
        _rb.rotation = rot;
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _runSpeed * _dashSpeed * Time.deltaTime);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            health -= 20;
        }
        else if (other.CompareTag("EnemyMelee"))
        {
            health -= 10;
        }
    }

    private void SetTrap()
    {
        Vector3 trapPos = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
        Instantiate(lightningTrap, trapPos, transform.rotation);
        lightningTrap.SetActive(true);
    }

    private void Execution()
    {
        animator.SetTrigger("Strangled");
        transform.Translate(transform.position.x, transform.position.y + 2, transform.position.z);
        health = 0;
    }
}


public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
