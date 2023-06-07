
using UnityEngine;

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
            Vector3 spawningPosition = link.position + new Vector3(Random.Range(-10f, 10f), 10f, Random.Range(-10f, 10f));
            Instantiate(enemyChicken, spawningPosition, new Quaternion(0f, 0f, 0f, 0f));
            timeElapsed = 0f;
        }
        timeElapsed += Time.deltaTime;
    }
}
