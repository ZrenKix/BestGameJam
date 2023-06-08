using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;

    WorldSpawner spawner;

    private void Start()
    {
        spawner = GetComponent<WorldSpawner>();
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            if (gameObject.GetComponent<LootDrop>() != null)
            {
                gameObject.GetComponent<LootDrop>().DropLoot();
                //spawner.DecreaseAmount(gameObject);
            }
            if (gameObject.GetComponent<BushLoot>() != null)
            {
                gameObject.GetComponent<BushLoot>().DropLootBush();
                //spawner.DecreaseAmount(gameObject);
            }

            if (gameObject.GetComponent<ChickenAI>() != null) GameObject.FindWithTag("Spawner").GetComponent<Spawner>().chickenSpawning = true;

            if (gameObject.GetComponent<Shatter>() != null && gameObject.CompareTag("PickUp")) gameObject.GetComponent<Shatter>().DestructPot();
            if(gameObject.GetComponent<Shatter>() != null && gameObject.CompareTag("Enemy")) gameObject.GetComponent<Shatter>().DestructBush();
            Destroy(gameObject);
            Debug.Log("Destroyed");
           
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