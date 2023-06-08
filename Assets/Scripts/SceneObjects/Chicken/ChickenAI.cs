using UnityEngine;

public class ChickenAI : MonoBehaviour
{
    public float moveSpeed = 1f;

    private float elapsedTime = 0;
    private float wait = 0;

    private float xDirection;
    private float zDirection;

    public bool move = false;

    // Player abuse
    private bool hitByPlayer = false;
    private float hTime = 2f;
    private float hTimer = 0f;

    Quaternion lookDirection;

    WorldSpawner spawner;

    private void Start()
    {
        moveSpeed = moveSpeed / 1000;
        xDirection = Random.Range(-3f, 3f);
        zDirection = Random.Range(-3f, 3f);
        spawner = GameObject.Find("WorldSpawner").GetComponent<WorldSpawner>();
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(xDirection * moveSpeed, 0, zDirection * moveSpeed);

        if (Random.Range(1, 1000) < 2)
        {
            move = false;
        }

        if (move)
        {
            transform.position += moveDirection;
        }

        lookDirection = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, 5 * Time.deltaTime);
        
        if (elapsedTime > wait)
        {
            xDirection = Random.Range(-3f, 3f);
            zDirection = Random.Range(-3f, 3f);
            move = true;
            elapsedTime = 0;
            wait = Random.Range(3, 10);
        }
        elapsedTime += Time.deltaTime;

        if (hitByPlayer)
        {
            hTimer += Time.deltaTime;
            if (hTimer > hTime)
            {
                hitByPlayer = false;
                hTimer = 0f;
            }
        }
    }

    public void EnableSpawner()
    {
        if (hitByPlayer)
        {
            spawner.GetComponent<Spawner>().chickenSpawning = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Sword"))
        {
            hitByPlayer = true;
            hTimer = 0f;
        }
    }
}
