using UnityEngine;

public class Health : MonoBehaviour
{
    private int health { get; set; }
    [SerializeField] private int maxHealth;

    public void takeDamage(int damage)
    {
        health--;
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