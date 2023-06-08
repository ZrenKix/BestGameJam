using UnityEngine;
using UnityEngine.AI;

public class FixAgent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Equals("Terrain"))
        {
            GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
