using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectableWithValue

{
    public int GetValue{get=>value;}

    [SerializeField] int value;

    public void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color (Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
        value = Random.Range(1,11);

    }
    public void Collect()
    {
        GameManager.Instance.AddCoins(value);

        print("Coletou uma moeda");

        gameObject.SetActive(false);
    }
     
         
    
}

