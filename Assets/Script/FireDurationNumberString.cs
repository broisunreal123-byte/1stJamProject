using UnityEngine;
using TMPro;
public class FireDurationNumberString : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fireAmount;
     public static FireDurationNumberString Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void UpdateDurationUI(int currenthp)
    {
      fireAmount.text = currenthp.ToString();  
    }
}
