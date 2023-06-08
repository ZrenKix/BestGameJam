using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private AudioClip ouch;
    [SerializeField] private AudioSource audioSource;

    public Health health;
    public int oldHealth = 2;
    
    
    private void Update()
    {
        if (oldHealth > health.getCurrentHealth())
        {
            audioSource.PlayOneShot(ouch);
            oldHealth = health.getCurrentHealth();
            

        }
        else if (health.getCurrentHealth() < oldHealth)
        {
            oldHealth = health.getCurrentHealth();
        }
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
    }
}
