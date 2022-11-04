using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementv2 : MonoBehaviour
{
    [Header("Player Controller")]
    public CharacterController controller;

    [Header("Settings")]
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 9f;

    [SerializeField] float gravity = -9.81f;
    [SerializeField] float groundDistance = 0.4f;

    [SerializeField] float maxStamina;
    [SerializeField] float staminaCoolDown = 1.2f;

    [SerializeField, Range(0f, 1f)] float staminaReduction;
    [SerializeField, Range(0f, 1f)] float staminaRegeneration;


    [Header("Ground Layers")]
    [SerializeField] LayerMask groundMask;

    [Header("Audio Manger")]
    public AudioManager audioManager;

    float currentSpeed;
    public float currentStamina;

    public static bool lockMovement = false;

    public Transform groundCheck;
    Vector3 velocity;
    bool isGrounded = false;
    bool blockStaminaRegeneration = false;


    private void Start()
    {
        //audioManager = GetComponent<AudioManager>();

        //audioManager = FindObjectOfType<AudioManager>();


        currentSpeed = walkSpeed;
        currentStamina = maxStamina;
    }

    private void FixedUpdate()
    {

        CheckInput();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (lockMovement)
            return;


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;


        }


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }


    void CheckInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0 && currentStamina > 0)
            Run();

        else
            Walk();



    }



    void Walk()
    {
        currentSpeed = walkSpeed;

        // Regenerate stamina:
        if (!blockStaminaRegeneration && currentStamina < maxStamina)
            currentStamina += staminaRegeneration;

        if (currentStamina > maxStamina)
            currentStamina = maxStamina;

    }


    void Run()
    {
        currentSpeed = runSpeed;

        currentStamina -= staminaReduction;


        if (currentStamina < 0)
        {
            currentStamina = 0;
            StartCoroutine(stopRunning());
        }

    }

    IEnumerator stopRunning()
    {
        blockStaminaRegeneration = true;
        yield return new WaitForSeconds(staminaCoolDown);

        blockStaminaRegeneration = false;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}
