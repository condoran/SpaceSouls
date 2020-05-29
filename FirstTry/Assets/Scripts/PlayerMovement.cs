using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float yPrev;
    public Vector3 hitNormal;

    public CharacterController ctrl;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    public float speed = 16f;
    public float gravity = -9;
    public float jumpHeight = 2f;

    Vector3 velocity;
    public bool isGrounded;
    public bool isCrouched = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        ctrl.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            ctrl.height = 1f;
            if (!isCrouched)
            {
                speed = speed * 1.5f;
                isCrouched = true;
            }
            else
            {
                if (speed > 7)
                {
                    if (Vector3.Angle(Vector3.up, hitNormal) > 120f)
                    { 
                        speed = speed;
                        Debug.Log("Muie!");
                    }
                    else if (Vector3.Angle(Vector3.up, hitNormal) < 90f)
                        speed = 0;
                    else
                        speed = speed * 0.995f;
                }
                else
                    speed = 7f;
            }
        }
        else
        {
            ctrl.height = 2f;
            speed = 16f;
            isCrouched = false;
        }

        velocity.y += gravity * Time.deltaTime;
        ctrl.Move(velocity * Time.deltaTime);
        yPrev = ctrl.transform.position.y;
        //Debug.Log(yPrev);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }
}
