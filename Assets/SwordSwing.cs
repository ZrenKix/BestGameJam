using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    private Animator animator;
    private bool attack = false;
    private float swingCoolDown = 1f;
    private float lastSwingTime;
    private Transform rightArm;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastSwingTime = -swingCoolDown;
        
        rightArm = transform.parent.parent;
    }

    public void PlaySwingAnimation()
    {
        float currentTime = Time.time;
        if (currentTime - lastSwingTime > swingCoolDown)
        {
            //animator.SetTrigger("Swing");
            transform.localRotation = Quaternion.Euler(0f, 90f, 90f);
            attack = true;
            lastSwingTime = currentTime;
            Debug.Log("Playing animation: Swing");
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && attack)
        {
            Health enemy = other.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.takeDamage(1);
                Debug.Log("Damaging enemy");
            }
        }
    }
}