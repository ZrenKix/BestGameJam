using UnityEngine;
using UnityEngine.AI;

public class WizardAI : MonoBehaviour
{
    public GameObject fireball;

    private NavMeshAgent agent;
    private Transform target;

    // Projectile timer
    private float timer = 0;
    public float cooldown = 2;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Walk towards player
        if (target != null)
        {
            agent.SetDestination(target.position);

            if (timer > cooldown)
            {
                timer = 0;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1))
                {
                    ShootFireBall();
                }
            }

            timer += Time.deltaTime;
        } else
        {
            agent.SetDestination(transform.position);
        }
    }

    private void ShootFireBall()
    {
        Instantiate(fireball, transform.position + transform.forward * 0.5f, transform.rotation);
    }
}
