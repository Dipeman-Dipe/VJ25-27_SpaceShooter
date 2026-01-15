using TMPro;
using UnityEngine;

public class Movimento : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI displayScore;

    int totalScore = 0;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, y, 0f) * 0.2f;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Fruta fruta = collision.GetComponent<Fruta>();

        fruta.Coletar();
        totalScore += fruta.Score;

        displayScore.text = totalScore.ToString();
    }

}
