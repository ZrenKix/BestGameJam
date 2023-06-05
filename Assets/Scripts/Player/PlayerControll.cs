using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;
    public float groundRaycastAvstånd = 0.1f;

    private bool springer = false;
    private bool hoppar = false;
    private bool ärPåMark = false;

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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastAvstånd);
    }
}