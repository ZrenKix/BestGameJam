using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;

    public Health health;

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
    }
}
