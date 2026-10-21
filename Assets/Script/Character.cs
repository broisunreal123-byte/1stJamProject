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
    protected float attackCooldown = 0f;
    protected float jumpForce = 8f;
    protected float facingDirection = 1f;
    protected bool Attacking = false;
    protected bool isGrounded;
    protected abstract void handleMovement();


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }



    public void TakeDamage()
    {
        hp -= dmg;
    }
    protected abstract void Attack();
    protected IEnumerator HitboxRoutine()
    {
        hitbox.SetActive(true);
        Attacking = true;
        yield return new WaitForSeconds(timeAttack);
        hitbox.SetActive(false);
        Attacking = false;
    }
}
