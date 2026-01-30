using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Freecam : MonoBehaviour


{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool grounded = false;

    void FixedUpdate()
    {
        if (grounded)
        {
            // Estamos no chão, então recalcule a direção de movimento diretamente dos eixos
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Aplicar gravidade
        moveDirection.y -= gravity * Time.deltaTime;

        // Mover o controlador
        CharacterController controller = GetComponent<CharacterController>();
        CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
        grounded = (flags & CollisionFlags.Below) != 0;
    }
}