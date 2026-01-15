using UnityEngine;

public class Fruta : MonoBehaviour
{

    [SerializeField] int score;

    public int Score { get => score; set => score = value; }

    public virtual void Coletar() 
    {
       Destroy(gameObject);
    }
}
