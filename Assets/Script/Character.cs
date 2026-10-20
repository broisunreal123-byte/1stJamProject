using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
     protected float hp;
     protected float dmg;
     protected float speed = 3.5f;
     protected Animator animate;
     protected GameObject hitbox;
    
    protected Rigidbody2D rb;
    

    protected float timeAttack;
    protected float attackCooldown = 0f;
    protected float jumpForce = 8f;
    protected bool Attacking = false;
    protected bool isGrounded;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        hitbox.SetActive(false);
    }



    public void TakeDamage()
    {
        hp -= dmg;
    }
    protected void Attack()
    {
        float timing = attackCooldown;
        if (isGrounded)
        {
            Debug.Log("Atacking");
            hitbox.SetActive(true);
            animate.SetTrigger("Attack");
            StartCoroutine(HitboxRoutine());
        }

    }
    protected IEnumerator HitboxRoutine()
    {
        hitbox.SetActive(true);
        Attacking = true;
        yield return new WaitForSeconds(timeAttack);
        hitbox.SetActive(false);
        Attacking = false;
    }
}
