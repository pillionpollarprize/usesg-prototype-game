using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform feet;
    public float speed = 7;
    public float jumpHeight = 1.5f;
    public float gravity = -9.8f;
    private CharacterController controller;
    public float y;
    private bool isGrounded;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(feet.position, 0.4f, groundLayer);

        if (isGrounded) y = 0;

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        //move according to input
        var move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;

        //jump
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            y += gravity * Time.deltaTime;
        }

        //apply gravity
        move.y = y * Time.deltaTime;

        controller.Move(move);
    }
    private void OnDrawGizmos()
    {
        if (feet != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(feet.position, 0.4f);
        }
    }
}
