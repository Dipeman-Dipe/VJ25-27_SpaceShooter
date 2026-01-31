using System;
using UnityEngine;


public enum PlayerForm
{
    Light,
    Shadow
}

public class Player : MonoBehaviour
{

    [SerializeField] PlayerForm currentForm = PlayerForm.Light;

    [SerializeField] private float speed = 1f;

    [SerializeField] private float jumpForce = 10f;

    [SerializeField] private int maxJump = 2;

    private int jumpcount;

    [SerializeField] public Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Color lightColor = Color.white;

    [SerializeField] private Color shadowColor = Color.black;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundCheckRadius = 0.2f;

    [SerializeField] private LayerMask groundLayer;

    private bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        CheckGround();
        Move();
        Jump();
        if (Input.GetKeyDown(KeyCode.Q))
            ToggleForm();
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpcount > maxJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            jumpcount++;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
            jumpcount = 0;
    }

    private void ToggleForm()
    {
        if (currentForm == PlayerForm.Light)
            SetForm(PlayerForm.Shadow);

        else
            SetForm(PlayerForm.Light);
    }
    private void SetForm(PlayerForm newForm)
    {
        currentForm = newForm;
        if (currentForm == PlayerForm.Light)
        {
            spriteRenderer.color = lightColor;
        }
        else
        {
            spriteRenderer.color = shadowColor;
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
