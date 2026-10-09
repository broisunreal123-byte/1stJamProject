using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private int FireDuration = 100;
    private int time = 1;
    public static Fire Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time)
        {
            time += 1;
            FireDuration -= 1;
            
            if(FireDuration<=100 && FireDuration>=0)
            {
                FireDurationNumberString.Instance.UpdateDurationUI(FireDuration);

            }
        }
        if (FireDuration >= 100)
            {
                FireDuration = 100;
                FireDurationNumberString.Instance.UpdateDurationUI(FireDuration);
            }
            else if (FireDuration <= 0)
            {
                FireDurationNumberString.Instance.UpdateDurationUI(0);

            }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Leaf"))
        {
            FireDuration += 20;
            FireDurationNumberString.Instance.UpdateDurationUI(FireDuration);
        }
    }

}
