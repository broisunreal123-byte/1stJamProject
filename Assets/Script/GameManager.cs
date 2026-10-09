using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject StartMenuUI;
    [SerializeField] private GameObject LoseMenuUI;
    [SerializeField] private GameObject WinMenuUI;
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
        LoseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
    }
    void Start()
    {
        Time.timeScale = 0f;
        
    }

    public void startGame()
    {
        StartMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void replayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LoseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
        Fire.Instance.restartFire();
    }
    public void showLoseMenu()
    {
        LoseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void showWinMenu()
    {
        WinMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
