using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] Transform cam; //Rotate on X

    [SerializeField] Transform mesh; // Rotate on Y

    [SerializeField] float sensiX = 200f;

    [SerializeField] float sensiY = 200f;

    float rotY;
    float rotX;

    [SerializeField] float minX = -90;

    [SerializeField] float maxX = 90;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotY = transform.eulerAngles.y;
        
        float camX = cam.localEulerAngles.x;

        if(camX > 180f)
        {
            camX -= 360f;
        }

        rotX = camX;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensiX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensiY;

        rotY += mouseX;
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX,minX,maxX);

        cam.localRotation = Quaternion.Euler(rotX,0f,0f);

        mesh.rotation = Quaternion.Euler(0f,rotY,0f);
    }
}
