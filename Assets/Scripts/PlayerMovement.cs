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

    public AudioManager aM;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

        //aM = GetComponent<AudioManager>();

        //aM = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Mouse X");

        vertical = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);

        Camera.main.transform.Rotate(-vertical * turnSpeed * Time.deltaTime, 0, 0);


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
