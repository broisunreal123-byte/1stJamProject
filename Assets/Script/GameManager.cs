using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject StartMenuUI;
    [SerializeField] private GameObject LoseMenuUI;
    [SerializeField] private GameObject WinMenuUI;
    [SerializeField] private GameObject TimeLimit;
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
        LoseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
        TimeLimit.SetActive(false);
    }
    void Start()
    {
        Time.timeScale = 0f;

    }

    public void startGame()
    {
        StartMenuUI.SetActive(false);
        Time.timeScale = 1f;
        TimeLimit.SetActive(true);
    }
    public void replayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LoseMenuUI.SetActive(false);
        WinMenuUI.SetActive(false);
    }
    public void showLoseMenu()
    {
        LoseMenuUI.SetActive(true);
        TimeLimit.SetActive(false);
        Time.timeScale = 0f;
    }
    public void showWinMenu()
    {
        WinMenuUI.SetActive(true);
        TimeLimit.SetActive(false);
        Time.timeScale = 0f;
    }
}
