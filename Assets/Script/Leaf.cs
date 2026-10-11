using System.Runtime.CompilerServices;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Transform target;
    private float distance = 1f;
    private bool isFollowing = false;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = true;
        }
        if (collision.CompareTag("Fireplace"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (!isFollowing) return;
        if (Vector2.Distance(transform.position, target.position) > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
