using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private float dmg = 25f;
    private float direction = 1;
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    
    void Update()
    {
        rb.linearVelocity = new Vector2(direction *speed, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Zombie zombie = collision.GetComponent<Zombie>();
            zombie.takeDamage(dmg);
            Destroy(gameObject);
        }
    }
    public void SetDirection(float dir)
    {
        direction = dir;
    }

    
}
