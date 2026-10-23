using UnityEngine;

public class HeroAttack : CharacterAttack
{
    void Start()
    {
        dmg = 30000000f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Character zombie = collision.GetComponent<Character>();
            zombie.TakeDamage(dmg);
        }
    }

}
