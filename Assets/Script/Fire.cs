using UnityEngine;

public class Fire : MonoBehaviour
{
    private int realFireDuration = 30;
    private int FireDuration;
    private float time = 1;
    public static Fire Instance;
    private int zombieDmg = 5;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        FireDuration = realFireDuration;
        time = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time)
        {
            time += 1;
            FireDuration -= 1;

            if (FireDuration <= realFireDuration && FireDuration >= 0)
            {
                FireDurationNumberString.Instance.UpdateFireDurationUI(FireDuration);

            }
        }
        if (FireDuration >= realFireDuration)
        {
            FireDuration = realFireDuration;
            FireDurationNumberString.Instance.UpdateFireDurationUI(realFireDuration);
        }
        else if (FireDuration <= 0)
        {
            FireDurationNumberString.Instance.UpdateFireDurationUI(0);
            GameManager.Instance.showLoseMenu();


        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Leaf"))
        {
            FireDuration += 20;
            FireDurationNumberString.Instance.UpdateFireDurationUI(FireDuration);
        }
        if (collision.CompareTag("Zombie"))
        {
            consumeFire(zombieDmg);
            Destroy(collision.gameObject);
            FireDurationNumberString.Instance.UpdateFireDurationUI(FireDuration);
        }
    }
    public void consumeFire(int dmg)
    {
        FireDuration -= dmg;
    }


}
