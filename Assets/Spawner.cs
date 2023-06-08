using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject enemyChicken;
    public Transform link;

    [SerializeField]
    private float timer = 5f;
    private float timeElapsed = 0f;

    public bool chickenSpawning = false;


    void Update()
    {
        
        if (chickenSpawning && timer < timeElapsed)
        {
            
            for(int i = 0; i < Random.Range(5, 10); i++)
            {
                Vector3 spawningPosition = link.position + new Vector3(Random.Range(-10, 10), 10f, Random.Range(-10, 10));
                GameObject chicken = Instantiate(enemyChicken, spawningPosition, new Quaternion(0f, 0f, 0f, 0f));
                chicken.GetComponent<NavMeshAgent>().enabled = false;
            }

            timeElapsed = 0f;
        }
        timeElapsed += Time.deltaTime;
    }
}
