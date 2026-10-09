using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private int FireDuration = 1;
    private float time = 1;
    public static Fire Instance;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        time = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time)
        {
            time += 1;
            FireDuration -= 1;
            
            if(FireDuration <= 30 && FireDuration>=0)
            {
                FireDurationNumberString.Instance.UpdateDurationUI(FireDuration);

            }
        }
        if (FireDuration >= 30)
            {
                FireDuration = 30;
                FireDurationNumberString.Instance.UpdateDurationUI(FireDuration);
            }
            else if (FireDuration <= 0)
            {
                FireDurationNumberString.Instance.UpdateDurationUI(0);
                GameManager.Instance.showLoseMenu();
                

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
    public void restartFire()
    {
        FireDuration = 30;
    }

}
