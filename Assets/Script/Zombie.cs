using UnityEngine;

public class Zombie : Character
{
    private Transform target;
    
    void Start()
    {
        speed = 3f;
        hp = 50f;
        target = GameObject.FindWithTag("Player").transform;
        
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
    
    
}
