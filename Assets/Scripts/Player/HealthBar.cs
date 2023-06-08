using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    ParticleSystem blood;


    public Health health;
    bool takeDamage = false; 
    int savedHealth = 0;
    
    private void Start() {
        blood = GetComponentInParent<ParticleSystem>();
        savedHealth = health.getCurrentHealth();
        blood.Stop();
    }
    private void Update()
    {
        if (health.getCurrentHealth() == 0)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
            
        }
        else if (health.getCurrentHealth() == 1)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(false);
        }
        else if (health.getCurrentHealth() >= 2)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
        }

        if(!takeDamage && savedHealth != health.getCurrentHealth()) {
            takeDamage = true;
            PlayBloodSplatter();
        }
    }

    private void PlayBloodSplatter() {
        if(takeDamage) {
            blood.Play();
            takeDamage = false;
            savedHealth = health.getCurrentHealth();
        }
    }
}
