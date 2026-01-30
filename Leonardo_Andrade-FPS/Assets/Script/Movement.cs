using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    [SerializeField] float drag = 3f;

    [SerializeField] Camera cam;

    Rigidbody rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    [SerializeField] Animator animator;

    [SerializeField] float movementAnimator = 1;

    [SerializeField] private float jumpForce = 8f;

    [SerializeField] private LayerMask groundedLayer;

    [SerializeField] private float groundCheckDistance = 0.2f;

    private bool grounded;

    float walkingMultiplayer = 0.5f;
    float runMultiplayer = 1f;




    void Update()
    {

        Vector3 forward = cam.transform.forward;
        
        Vector3 right = cam.transform.right;

        right.y = 0;

        forward.y = 0;

        forward.Normalize();

        right.Normalize();

        float v = Input.GetAxisRaw("Vertical");

        float h = Input.GetAxisRaw("Horizontal");

        Vector3 vel = rb.linearVelocity;

        Vector3 move = (forward * v + right * h).normalized;

        Vector3 targetVel = move * speed;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            targetVel *= runMultiplayer;
        }
        else
        {
            targetVel *= walkingMultiplayer;
        }


        
        Debug.Log("Update OK");

        Debug.DrawRay(transform.position, Vector3.down, Color.green);

        CheckGround();
        


        targetVel.y = vel.y;

        rb.linearVelocity = Vector3.Lerp(vel, targetVel, drag*Time.deltaTime);

        Vector3 velAfterAtribution = rb.linearVelocity;

        velAfterAtribution.y = 0;

        animator.SetFloat("PlayerSpeed", velAfterAtribution.magnitude/(speed*movementAnimator));

        CheckGround();

        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }

    void CheckGround()
    {
        Vector3 origin = transform.position + Vector3.up * 0.1f;

        Debug.DrawRay(origin, Vector3.down * groundCheckDistance, Color.red);

        grounded = Physics.Raycast(origin,Vector3.down,groundCheckDistance,groundedLayer);


    }
}
