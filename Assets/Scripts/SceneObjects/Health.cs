using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void increaseHealth(int health)
    {
        int newHealth = this.health += health;
         if (newHealth <= maxHealth)
        {
            this.health = newHealth;
        } 
        
    }

}