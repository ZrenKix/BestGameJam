using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 3f;

    [SerializeField] private float time = 5f;
    [SerializeField] private float timeElapsed = 5f;

    private void Update()
    {
        if (timeElapsed > time)
        {
            DealDamage();
            Destroy(gameObject);
        }

        timeElapsed += Time.deltaTime;
    }

    public void DealDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Health health = collider.GetComponent<Health>();
            if (health != null)
            {
                collider.GetComponent<Health>().takeDamage(2);
            }
        }
    }
}
