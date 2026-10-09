using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float speed = 3f;
    private float distance = 1f;
    private bool isFollowing = false;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = true;
        }
    }
    void Update()
    {
        if (!isFollowing) return;
        if (Vector2.Distance(transform.position, Player.position) > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
    }
}
