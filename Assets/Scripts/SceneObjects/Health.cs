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
            if (gameObject.GetComponent<BushLoot>() != null) gameObject.GetComponent<BushLoot>().DropLootBush();
            if (gameObject.GetComponent<ChickenAI>() != null) GameObject.FindWithTag("Spawner").GetComponent<Spawner>().chickenSpawning = true;

            if (gameObject.GetComponent<Shatter>() != null && gameObject.CompareTag("PickUp")) gameObject.GetComponent<Shatter>().DestructPot();
            if(gameObject.GetComponent<Shatter>() != null && gameObject.CompareTag("Enemy")) gameObject.GetComponent<Shatter>().DestructBush();
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