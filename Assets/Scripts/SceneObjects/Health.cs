using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public void takeDamage()
    {
        health--;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}