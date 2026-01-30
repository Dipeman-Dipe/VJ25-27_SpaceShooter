using System;
using UnityEngine;


public class Movement : MonoBehaviour
#region Declarations
   
{   
    private Rigidbody2D rb;

    [SerializeField] private float speed;

    [SerializeField] private float maxSpeed;

    [SerializeField] private float jumpForce = 10;

    [SerializeField] private float distance = 1;

    [SerializeField] private LayerMask whatIsGround;

    public int health = 1;

    [SerializeField] GameObject lastCheckpoint;
    private float input;

    private States playerStates;

    [SerializeField] private Animator playerAnimator;

    [SerializeField] private SpriteRenderer spriteRenderer;
#endregion
#region MonoBehaviour
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() == true)
        {
            Jump();        
        }

        StateMachine();
    }
#endregion
#region MovementFunctions
    void Move()
    {
        rb.AddForce(Vector2.right * input * speed, ForceMode2D.Force);

        if (rb.linearVelocity.x > maxSpeed)
            rb.linearVelocity = new Vector2(maxSpeed, rb.linearVelocity.y);
        else if (rb.linearVelocity.x < -maxSpeed)
            rb.linearVelocity = new Vector2(-maxSpeed, rb.linearVelocity.y);

        if(rb.linearVelocity == Vector2.zero)
        {
            playerStates = States.Idle;
        }
        else 
        {
            playerStates = States.Walking;

            if(rb.linearVelocity.x > 0.2)
                spriteRenderer.flipX = false;
            else if(rb.linearVelocity.x < -0.2)
                spriteRenderer.flipX = true;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        print("Saltei!");
        playerStates = States.Jumping;
        //playerStates = States.;           
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position,Vector2.down, distance, whatIsGround);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distance);

    }
#endregion

    public void TakeDamage(int damage)
    {
        health -= damage;

        UiManager.Instance.ChangeLifeUI(health);

        if(health <=0)
        {
            gameObject.SetActive(false);
            Die();
        }
    }

    public void Die()
    {
        health = 1;
        transform.position = lastCheckpoint.transform.position;
        gameObject.SetActive(true);
        UiManager.Instance.ChangeLifeUI(health);


        //GameManager.Instance.GameOver();
    }


    void Respawn()
    {   
        health = 3;
        transform.position = lastCheckpoint.transform.position;
        gameObject.SetActive(true);
        
    }

    void StateMachine()
    {

        playerAnimator.SetInteger("State",(int)playerStates);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            lastCheckpoint = collision.gameObject;
        }

        ICollectable collectable = collision.GetComponent<ICollectable>();
        collectable.Collect();

       
    }


    enum States
    {
        Idle,
        Walking,
        Jumping,
    }



}