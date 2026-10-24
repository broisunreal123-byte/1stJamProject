
using UnityEngine;
using System.Collections;




public class Hero : Character
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private float checkRadius = 0.1f;
    void Start()
    {
        hitbox.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        hp = 100f;
        dmg = 50f;
        timeAttack = 1f;
        attackCooldown = 3f;


    }

    // Update is called once per frame
    void Update()
    {
         if (hp <= 0)
        {
            playDeath();
        } else
        {
            handleMovement();
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        animate.SetBool("isJumping", !isGrounded);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump();

        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= hitboxAppearance)
        {
            hitboxAppearance = Time.time + timeAttack;
            Attack();

        }
        


    }
    protected override void handleMovement()
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
    protected override void Attack()
    {
        float timing = hitboxAppearance;
        if (isGrounded)
        {
            Debug.Log("Atacking");
            hitbox.SetActive(true);
            animate.SetTrigger("Attack");
            StartCoroutine(HitboxRoutine());
        }

    }
    public void playDeath()
    {
        StartCoroutine(PlayDeathAnimation());
        transform.Translate(Vector3.right * 0 * speed * Time.deltaTime);
        animate.SetBool("isJumping", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
    public IEnumerator PlayDeathAnimation()
    {
        animate.SetTrigger("Death");
        yield return new WaitForSeconds(3f);
        GameManager.Instance.showLoseMenu();
    }

}
