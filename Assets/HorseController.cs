using System;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;
    public KeyCode rideKey = KeyCode.E;

    private bool isRiding = false;
    private GameObject horse;
    private Animator horseAnimator;
    private Rigidbody horseRigidbody;
    public PlayerControll playerControll;

    void Start()
    {
        horse = GameObject.FindWithTag("Horse");
        horseAnimator = horse.GetComponent<Animator>();
        horseRigidbody = horse.GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (!isRiding && Input.GetKeyDown(rideKey))
        {
            MountHorse();
        }
        else if (isRiding && Input.GetKeyDown(rideKey))
        {
            DismountHorse();
        }

        if (isRiding)
        {
            HandleHorseMovement();
            HandleHorseJump();
        }
    }

    void MountHorse()
    {
        if (!isRiding)
        {
            isRiding = true;
            playerControll.enabled = false;
            horseRigidbody.isKinematic = true;
            transform.SetParent(horse.transform);
            transform.localPosition = new Vector3(0f, 1.5f, 0f);
            //horseAnimator.SetBool("IsRiding", true);
        }
    }

    void DismountHorse()
    {
        if (isRiding)
        {
            isRiding = false;
            playerControll.enabled = true;
            horseRigidbody.isKinematic = false;
            horse.transform.SetParent(null);
           // horseAnimator.SetBool("IsRiding", false);
        }
    }

    void HandleHorseMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            horseRigidbody.MoveRotation(Quaternion.Lerp(horseRigidbody.rotation, targetRotation, 10f * Time.deltaTime));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement *= sprintSpeed;
            }
            else
            {
                movement *= walkSpeed;
            }

            horseRigidbody.velocity = movement;

            
        }
        else
        {
            horseRigidbody.velocity = Vector3.zero;
            //horseAnimator.SetBool("Running", false); // Disable the "Run" animation state
        }
    }

    void HandleHorseJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            horseRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}