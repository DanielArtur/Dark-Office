using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float mouseSensitivy = 100f;


    public Transform playerBody;

    float xRotation = 0f;

    public static bool lockCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (lockCamera)
            return;


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivy * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);



    }
}
