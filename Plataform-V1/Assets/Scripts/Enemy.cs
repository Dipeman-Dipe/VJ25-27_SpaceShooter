using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Transform[] pontos;

    [SerializeField] private float speed = 1f;

    [SerializeField] private float distance = 1;

    [SerializeField] private int damage = 1;

    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private int pontosIndex;

    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
        pontosIndex = 0;
    }

    private void Update()
    {
        Vector3 targetPos = pontos[pontosIndex].position;
        Vector3 dir = targetPos - transform.position;

        // Movimento
        transform.position += dir.normalized * speed * Time.deltaTime;

        // Flip do sprite
        if (dir.x != 0)
        {
            spriteRenderer.flipX = dir.x < 0;
        }

        // Chegou no ponto
        if (Vector3.Distance(transform.position, targetPos) <= 0.1f)
        {
            pontosIndex++;

            if (pontosIndex >= pontos.Length)
            {
                pontosIndex = 0;
            }
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void ResetEnemy()
    {
        pontosIndex = 0;
        transform.position = startPosition;
        gameObject.SetActive(true);
    }

    // 👉 DANO LATERAL
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movement player = collision.gameObject.GetComponent<Movement>();
        if (player == null) return;

        // Normal aponta para onde a força veio
        Vector2 normal = collision.contacts[0].normal;

        // Se NÃO veio de cima, causa dano
        if (normal.y > -0.5f)
        {
            player.TakeDamage(1);
        }
    }
    
}


