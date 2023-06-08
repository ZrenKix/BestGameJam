using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damageAmount = 1;
    public float projectileSpeed = 1f;

    private float duration = 3;
    private float timer = 0;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileSpeed / 5000);
    }

    private void Update()
    {
        if (timer > duration)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision != null && collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().takeDamage(1);
            Destroy(gameObject);
        }
    }
}
