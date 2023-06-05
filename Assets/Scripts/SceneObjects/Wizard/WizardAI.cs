using UnityEngine;
using UnityEngine.AI;

public class WizardAI : MonoBehaviour
{
    private int health = 50;

    private NavMeshAgent agent;
    private Transform playerPosition;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Walk towards player
        agent.SetDestination(playerPosition.position);

        if (health < 0)
        {
            Destroy(this);
        }
    }

    public void TakeDamage()
    {
        health--;
    } 

    private void ShootFireBall()
    {

    }

}
