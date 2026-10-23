using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
   [SerializeField] private float dmg;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Character target = collision.GetComponent<Character>();
            Debug.Log(target);
            target.TakeDamage(dmg);
            Debug.Log(dmg);
        }
    }
}
