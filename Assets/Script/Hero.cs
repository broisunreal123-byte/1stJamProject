using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using UnityEditor.Callbacks;
using NUnit.Framework;

public class Hero : Character
{

    [SerializeField] private float speed = 3.5f;
    [SerializeField] private Animator animate;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    private Rigidbody2D rb;
    private float checkRadius = 0.5f;

    private float timeAttack = 0.75f;
    private float attackCooldown = 0f;
    private float jumpForce = 5f;
    private bool Attacking = false;
    private bool isGrounded;



    private float facingDirection = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= attackCooldown)
        {
            attackCooldown = Time.time + timeAttack;
            Attack();

        }
        Debug.Log(isGrounded);

    }
    private void handleMovement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (Attacking)
        {
            transform.Translate(Vector3.right * 0 * speed * Time.deltaTime);
        }
        else
        {
            if (input != 0)
            {
                animate.SetBool("isRunning", true);
                facingDirection = input;
                transform.localScale = new Vector3(5 * facingDirection, 5, 1);
            }
            else
            {
                animate.SetBool("isRunning", false);
            }
            transform.Translate(Vector3.right * input * speed * Time.deltaTime);
        }


    }
    private void jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpForce);
        animate.SetBool("isJumping",true);
    }
    private void Attack()
    {
        float timing = attackCooldown;
        Debug.Log("Atacking");
        hitbox.SetActive(true);
        animate.SetTrigger("Attack");
        StartCoroutine(HitboxRoutine());

    }
    private IEnumerator HitboxRoutine()
    {
        hitbox.SetActive(true);
        Attacking = true;
        yield return new WaitForSeconds(timeAttack);
        hitbox.SetActive(false);
        Attacking = false;
        Debug.Log("Success");
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

}
