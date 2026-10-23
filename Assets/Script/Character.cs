using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    protected float hp;
    protected float dmg;
    protected float speed = 3.5f;
    [SerializeField] protected Animator animate;
    [SerializeField] protected GameObject hitbox;

    protected Rigidbody2D rb;


    protected float timeAttack;
    protected float hitboxAppearance = 0f;
    protected float attackCooldown;
    protected float jumpForce = 8f;
    protected float facingDirection = 1f;
    protected bool Attacking = false;
    protected bool isGrounded;
    protected abstract void handleMovement();


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    protected void onDeath()
    {
        
    }


    public void TakeDamage(float dmg)
    {
        hp -= dmg;
    }
    protected abstract void Attack();
    protected IEnumerator HitboxRoutine()
    {
        hitbox.SetActive(true);
        Attacking = true;
        yield return new WaitForSeconds(0.6f);
        hitbox.SetActive(false);
        Attacking = false;
    }
}
