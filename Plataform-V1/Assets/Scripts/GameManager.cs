using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] GameObject winPanel;

    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Coin[] coins;

    public int currentCheckpoint = 0;

    static GameManager instance;
    int coinsInTotal = 0;

    public static GameManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        enemies = Object.FindObjectsByType<Enemy>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        coins = Object.FindObjectsByType<Coin>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void AddCoins(int coinToAdd)
    {
        coinsInTotal += coinToAdd;
        UiManager.Instance.UpdateCoinUI(coinsInTotal);
    }

    public void ResetLevel()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.checkpointIndex > currentCheckpoint)
                enemy.ResetEnemy();
        }
    }

    public void ResetCoins()
    {
        foreach (Coin coin in coins)
        {
            if (coin.checkpointIndex > currentCheckpoint)
                coin.ResetCoin();
        }
    }

    public void ResetCoinValue()
    {
        coinsInTotal = 0;
        UiManager.Instance.UpdateCoinUI(coinsInTotal);
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

