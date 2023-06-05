using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;
    public float groundRaycastAvstånd = 0.1f;
    public float pickupRaycastDistance = 2f;

    private bool springer = false;
    private bool hoppar = false;
    private bool ärPåMark = false;
    private bool isCarrying = false;
    private GameObject carriedObject;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }

        if (springer)
        {
            movement *= sprintSpeed;
        }
        else
        {
            movement *= walkSpeed;
        }

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);


        if (ärPåMark && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            ärPåMark = false;
            Debug.Log("Hopp");
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
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundRaycastAvstånd))
        {
            ärPåMark = true;
            Debug.Log("Jag står på marken");
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
                carriedObject.GetComponent<Rigidbody>().isKinematic = true;
                carriedObject.transform.SetParent(transform);
                carriedObject.transform.localPosition = new Vector3(0f, 0.5f, 1f);
                isCarrying = true;
            }
        }
    }

    void CarryObject()
    {
        carriedObject.transform.position = transform.position + transform.forward * 1.5f;
        carriedObject.GetComponent<Rigidbody>().velocity = rb.velocity;
    }

    void DropObject()
    {
        carriedObject.transform.SetParent(null);
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
        isCarrying = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastAvstånd);

        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * pickupRaycastDistance);
    }
}
