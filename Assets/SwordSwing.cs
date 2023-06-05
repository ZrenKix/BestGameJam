using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    private Animator animator;
    private bool attack = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void PlaySwingAnimation()
    {
        //animator.SetTrigger("Swing");
        attack = true;
        transform.Rotate(0f, 0f, 90f);
        Debug.Log("Spela animation");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && attack == true)
        {
            Health enemy = other.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.takeDamage();
                Debug.Log("Skadar enemy");
            }
        }
    }
}