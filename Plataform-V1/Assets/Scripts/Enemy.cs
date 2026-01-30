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

    [SerializeField] private BoxCollider2D boxCollider;

    public int checkpointIndex;

    private Rigidbody2D rb;

    private int pontosIndex;

    private Vector3 startPosition;

    private bool isDead;

    private void Awake()
    {
        startPosition = transform.position;
        pontosIndex = 0;
    }

    private void Update()
    {
        if (isDead) return;

        Vector3 targetPos = pontos[pontosIndex].position;
        Vector3 dir = targetPos - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;

  
        if (dir.x != 0)
        {
            spriteRenderer.flipX = dir.x < 0;
        }

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
        if (isDead) return;
        isDead = true;

        spriteRenderer.enabled = false;
        boxCollider.enabled = false;

        if (rb != null)
            rb.simulated = false;
    }

    public void ResetEnemy()
    {
        isDead = false;
        pontosIndex = 0;
        transform.position = startPosition;

        spriteRenderer.enabled = true;
        boxCollider.enabled = true;

        if (rb != null)
            rb.simulated = true;
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movement player = collision.gameObject.GetComponent<Movement>();
        if (player == null) return;

       
        Vector2 normal = collision.contacts[0].normal;

      
        if (normal.y > -0.5f)
        {
            player.TakeDamage(1);
        }
    }
    
}


