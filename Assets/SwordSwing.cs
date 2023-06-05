using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlaySwingAnimation()
    {
        animator.SetTrigger("Swing");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health enemy = other.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.takeDamage();
            }
        }
    }
}