using Unity.Mathematics;
using UnityEngine;

public class Hero : Character
{

    [SerializeField] private float speed = 3.5f;
    [SerializeField] private Animator animate;
    [SerializeField] private GameObject hitbox;
    float timeAttack = 1.5f;
    
    
    float attackCooldown = 0f;


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
        } else if (Time.time >= attackCooldown)
        {
            hitbox.SetActive(false);
        }

    }
    private void handleMovement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * input * speed * Time.deltaTime);
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
    }
    private void Attack()
    {
        Debug.Log("Atacking");
        hitbox.SetActive(true);
        animate.SetTrigger("Attack");

    }

}
