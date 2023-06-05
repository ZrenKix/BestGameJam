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
}