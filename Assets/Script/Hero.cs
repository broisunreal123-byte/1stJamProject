using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class Hero : Character
{

    [SerializeField] private float speed = 3.5f;
    [SerializeField] private Animator animate;
    [SerializeField] private GameObject hitbox;
    float timeAttack = 0.75f;
    float attackCooldown = 0f;
    bool Attacking = false;


    private float facingDirection = 1f;
    void Start()
    {
        hitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        if (Input.GetKeyDown("space") && Time.time >= attackCooldown)
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

}
