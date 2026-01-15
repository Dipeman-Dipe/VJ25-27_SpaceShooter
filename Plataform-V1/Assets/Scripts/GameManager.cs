using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] GameObject gameOverPanel;

   static GameManager instance;

   int coinsInTotal = 0;

    public static GameManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);    
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void AddCoins(int coinToAdd)
    {
        coinsInTotal += coinToAdd;
    }


}
