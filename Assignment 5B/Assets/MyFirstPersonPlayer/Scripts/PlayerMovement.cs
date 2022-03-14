/* Robert Krawczyk
 * Assignment 5B - 3D FPS
 * Move, jump, gravity
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public float speed = 12;

    public Vector3 velocity;
    public float gravity = -9.81f;
    public float gravityMultiplier = 2;

    Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public float jumpHeight = 3;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gravity *= gravityMultiplier;
        groundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        // Grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 2;
        }

        // Movement
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        controller.Move(velocity);

        

         
    }
}
