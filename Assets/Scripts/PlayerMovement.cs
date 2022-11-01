using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private float moveSpeed = 1000;

    private float turnSpeed = 150;

    private float horizontal;

    private float vertical;

    private Rigidbody rb;

    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Mouse X");

        vertical = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);

        //transform.Rotate(Vector3.right * vertical * turnSpeed * Time.deltaTime);


        if (canMove == true)
        {



            if (Input.GetKey(KeyCode.W))
            {

                rb.velocity = transform.forward * moveSpeed * Time.deltaTime;





                //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            }


            else if (Input.GetKey(KeyCode.S))
            {


                rb.velocity = transform.forward * -moveSpeed * Time.deltaTime;



                //transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

            }



            else if (Input.GetKey(KeyCode.A))
            {

                rb.velocity = transform.right * -moveSpeed * Time.deltaTime;

            }

            else if (Input.GetKey(KeyCode.D))
            {

                rb.velocity = transform.right * moveSpeed * Time.deltaTime;

            }

            else
            {

                rb.velocity = transform.right * 0 * Time.deltaTime;

                rb.velocity = transform.forward * 0 * Time.deltaTime;

            }

        }

    }

}
