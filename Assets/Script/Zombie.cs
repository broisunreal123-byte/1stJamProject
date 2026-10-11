using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Transform target;
    private float hp = 100;
    private float speed = 2f;
    void Start()
    {
        target = GameObject.FindWithTag("Fireplace").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        if (target == null)
        {
            return;
        }
    }
    
    public void takeDamage(float dmg)
    {
        hp -= dmg;
    }
}
