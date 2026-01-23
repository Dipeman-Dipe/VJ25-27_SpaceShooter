using Unity.VisualScripting;
using UnityEngine;

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

        targetVel.y = vel.y;

        rb.linearVelocity = Vector3.Lerp(vel, targetVel, drag*Time.deltaTime);

        Vector3 velAfterAtribution = rb.linearVelocity;

        velAfterAtribution.y = 0;

        animator.SetFloat("PlayerSpeed", velAfterAtribution.magnitude/(speed*movementAnimator));

    }
}
