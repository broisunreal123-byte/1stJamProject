using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using UnityEditor.Callbacks;
using NUnit.Framework;

public class Hero : Character
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private float checkRadius = 0.1f;
    private float facingDirection = 1f;
    void Start()
    {
        hp = 100f;
        dmg = 50f;
        timeAttack = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        animate.SetBool("isJumping", !isGrounded);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump();

        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= attackCooldown)
        {
            attackCooldown = Time.time + timeAttack;
            Attack();

        }



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

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

    }

   

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

}
