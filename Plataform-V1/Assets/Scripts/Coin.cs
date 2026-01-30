using UnityEngine;

public class Coin : MonoBehaviour, ICollectableWithValue
{
    public int GetValue => value;

    [SerializeField] private int value;

    [SerializeField] public int checkpointIndex;

    private Vector3 startPosition;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        

        value = 1;
    }

    public void Collect()
    {
        GameManager.Instance.AddCoins(value);
        Debug.Log("Coletou uma moeda");

        gameObject.SetActive(false);
    }


    public void ResetCoin()
    {
        transform.position = startPosition;
        gameObject.SetActive(true);
    }
}






