using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class WizardAI : MonoBehaviour
{
    private int health = 50;

    public GameObject fireball;

    private NavMeshAgent agent;
    private Transform playerPosition;

    // Projectile timer
    private float timer = 0;
    public float cooldown = 2;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Walk towards player
        agent.SetDestination(playerPosition.position);

        if (timer > cooldown)
        {
            timer = 0;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1))
            {
                ShootFireBall();
            }
        }

        if (health < 0)
        {
            Destroy(this);
        }

        timer += Time.deltaTime;
    }

    public void TakeDamage()
    {
        health--;
    } 

    private void ShootFireBall()
    {
        Instantiate(fireball, transform.position, new quaternion());
    }
}
