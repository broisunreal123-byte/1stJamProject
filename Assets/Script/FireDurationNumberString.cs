using UnityEngine;
using TMPro;
public class FireDurationNumberString : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI timingDuration;
     public static FireDurationNumberString Instance;
    void Awake()
    {
        Instance = this;
    }
    
    public void UpdateTimeDurationUI(int timeDuration)
    {
        timingDuration.text = timeDuration.ToString();
    }
}
