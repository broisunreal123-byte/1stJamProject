
using UnityEngine;



public class Zombie : Character
{
    private Transform target;
    private float distance;

    void Start()
    {
        hitbox.SetActive(false);
        speed = 3f;
        hp = 50f;
        target = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);
        handleMovement();

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        if (target == null)
        {
            return;
        }
        if (Time.time >= attackCooldown && distance <= 1.5f)
        {
            attackCooldown = Time.time + timeAttack;
            Attack();

        }
    }
    protected override void handleMovement()
    {
        float input = Mathf.Sign(target.position.x - transform.position.x);
        float inputspeed = speed;


        if (Attacking)
        {
            inputspeed = 0f;
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
            inputspeed = speed;
            transform.position = Vector2.MoveTowards(transform.position, target.position, inputspeed * Time.deltaTime);
        }
    }
    protected override void Attack()
    {
        float timing = attackCooldown;
        Debug.Log("Atacking");
        hitbox.SetActive(true);
        animate.SetTrigger("Attack");
        StartCoroutine(HitboxRoutine());
    }


}
