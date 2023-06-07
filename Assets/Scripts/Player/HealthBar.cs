using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;

    public Health health;

    private void Update()
    {
        for (int i = 0; i < health.getCurrenthealth(); i++)
        {
            hearts[i].SetActive(false);
            hearts[-i].SetActive(true);
        }
    }
}
