using UnityEngine;

public class TimeDuration : MonoBehaviour
{
    private int realTimeDuration = 10;
    private int timeDuration;
    private float time = 0f;
    void Awake()
    {
        timeDuration = realTimeDuration;
    }
    void Start()
    {
        FireDurationNumberString.Instance.UpdateTimeDurationUI(realTimeDuration);
        time = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time)
        {
            time += 1;
            timeDuration -= 1;
             FireDurationNumberString.Instance.UpdateTimeDurationUI(timeDuration);
            if (timeDuration <= 0)
            {
                GameManager.Instance.showWinMenu();
            }
        }
    }
    
}
