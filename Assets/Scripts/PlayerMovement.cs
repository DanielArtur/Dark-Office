using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private float moveSpeed = 100;

    private float turnSpeed = 150;

    private float horizontal;

    private float vertical;

    private Rigidbody rb;

    public static bool canMove = true;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        horizontal = Input.GetAxis("Mouse X");

        vertical = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);

        Camera.main.transform.Rotate(-vertical * turnSpeed * Time.deltaTime, 0, 0);


        if (canMove == true)
        {


            if (Input.GetKey(KeyCode.W))
            {
                Vector3 velocity = transform.forward * moveSpeed * Time.deltaTime;
                velocity.y = rb.velocity.y;
                rb.velocity = velocity;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Vector3 velocity = transform.forward * -moveSpeed * Time.deltaTime;
                velocity.y = rb.velocity.y;
                rb.velocity = velocity;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Vector3 velocity = transform.right * -moveSpeed * Time.deltaTime;
                velocity.y = rb.velocity.y;
                rb.velocity = velocity;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Vector3 velocity = transform.right * moveSpeed * Time.deltaTime;
                velocity.y = rb.velocity.y;
                rb.velocity = velocity;
            }
            else
            {
                Vector3 velocity = Vector3.zero;
                velocity.y = rb.velocity.y;
                rb.velocity = velocity;
            }

        }

    }

}
