using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float hp = 100;
    private float speed = 2f;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void takeDamage(float dmg)
    {
        hp -= dmg;
    }
}
