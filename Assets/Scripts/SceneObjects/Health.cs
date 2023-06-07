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
        if (health < 1)
        {
            if (gameObject.GetComponent<LootDrop>() != null) gameObject.GetComponent<LootDrop>().DropLoot();
            if (gameObject.GetComponent<ChickenAI>() != null) GameObject.FindWithTag("Spawner").GetComponent<Spawner>().chickenSpawning = true;

            if (gameObject.GetComponent<Shatter>() != null) gameObject.GetComponent<Shatter>().DestructPot();
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
    public int getCurrentHealth()
    {
        return health;
    }

}