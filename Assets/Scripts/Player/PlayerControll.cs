using System;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;
    public float groundRaycastAvstånd = 0.1f;
    public float pickupRaycastDistance = 2f;

    private float throwForce = 4f;

    private bool springer = false;
    private bool hoppar = false;
    private bool ärPåMark = false;
    private bool isCarrying = false;
    private GameObject carriedObject;
    private SwordSwing swordSwing;
    private Animator animator;
    public ParticleSystem dust;

    private int defaultLayer;
   

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        swordSwing = GetComponentInChildren<SwordSwing>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

            if (springer)
            {
                movement *= sprintSpeed;
            }
            else
            {
                movement *= walkSpeed;
            }

            animator.SetBool("Running", true); // Enable the "Run" animation state
        }
        else
        {
            movement = Vector3.zero;
            animator.SetBool("Running", false); // Disable the "Run" animation state
        }

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);


        if (Input.GetButtonDown("Jump"))
        {
            AttackSword();
            
        }
       

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            springer = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            springer = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isCarrying)
            {
                PickUpObject();
                Debug.Log("Pick uped object");
            }
            else
            {
                DropObject();
                Debug.Log("yeeet");
            }
        }
        if (isCarrying)
        {
            CarryObject();
            Debug.Log("jag bär på något");
        }
        if (movement.magnitude > 0.1f)
        {
            CreateDust();
        }
    }

    void AttackSword()
    {
        if(swordSwing != null)
        {
            swordSwing.PlaySwingAnimation();
        }

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundRaycastAvstånd))
        {
            ärPåMark = true;
            //Debug.Log("Jag står på marken");
        }
        else
        {
            ärPåMark = false;
            Debug.Log("Jag är i luften");
        }
    }

    void PickUpObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRaycastDistance))
        {
            if (hit.collider.CompareTag("PickUp"))
            {
                carriedObject = hit.collider.gameObject;
                defaultLayer = carriedObject.layer;

               
                int carriedObjectLayer = LayerMask.NameToLayer("CarriedObject");
                carriedObject.layer = carriedObjectLayer;

               
                int playerLayer = LayerMask.NameToLayer("Player");
                Physics.IgnoreLayerCollision(playerLayer, carriedObjectLayer, true);

                carriedObject.GetComponent<Rigidbody>().isKinematic = true;
                carriedObject.transform.SetParent(transform);
                carriedObject.transform.localPosition = new Vector3(0f, 0.5f, 0.5f);
                isCarrying = true;
            }
        }
    }

    void CarryObject()
    {
        Vector3 desiredPosition = transform.position + transform.forward * 1f + Vector3.up * 0.5f;
        carriedObject.transform.position = desiredPosition;
        carriedObject.GetComponent<Rigidbody>().velocity = rb.velocity;
    }

    void DropObject()
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        int carriedObjectLayer = LayerMask.NameToLayer("CarriedObject");
        Physics.IgnoreLayerCollision(playerLayer, carriedObjectLayer, false);

        carriedObject.transform.SetParent(null);
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject.layer = defaultLayer;
        carriedObject.layer = defaultLayer;

        Rigidbody carriedObjectRb = carriedObject.GetComponent<Rigidbody>();

        Vector3 throwDirection = transform.forward + Vector3.up; 

        carriedObjectRb.velocity = throwDirection * throwForce;
        carriedObjectRb.angularVelocity = new Vector3(0f, 2f, 0f); 
        carriedObject = null;
        isCarrying = false;
    }

    void CreateDust()
    {
        dust.Play();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastAvstånd);

        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * pickupRaycastDistance);
    }
}
