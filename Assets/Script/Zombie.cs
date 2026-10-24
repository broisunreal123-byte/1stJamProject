
using UnityEngine;
using System.Collections;



public class Zombie : Character
{
    private Transform target;
    private float distance;
    private GameObject heroObject;
    private float stopdist = 1.5f;

    void Start()
    {
        hitbox.SetActive(false);
        speed = 3f;
        hp = 50f;
        timeAttack = 1.5f;
        attackCooldown = 6f;
        target = GameObject.FindWithTag("Player").transform;
        heroObject = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance >= stopdist && hp > 0)
        {
            handleMovement();
            
        } else
        {
            animate.SetBool("isRunning", false);
        }
        

        if (hp <= 0)
        {
            PlayDeath();
            
        }
        

        if (Time.time >= hitboxAppearance && distance <= 1.5f)
        {
            hitboxAppearance = Time.time + timeAttack;
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
            if (target == null)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, inputspeed * Time.deltaTime);
            }
        }
    }
    protected override void Attack()
    {

        float timing = hitboxAppearance;
        hitbox.SetActive(true);
        animate.SetTrigger("Attack");
        StartCoroutine(HitboxRoutine());
    }
    private void PlayDeath()
    {
        
        StartCoroutine(PlayDeathAnimation());
        hitbox.SetActive(false);
    }
    public IEnumerator PlayDeathAnimation()
    {
        animate.SetTrigger("Death");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    


}
