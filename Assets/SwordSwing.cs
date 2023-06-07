using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public GameObject link;
    private Animator animator;
    private bool attack = false;
    private float swingCoolDown = 1f;
    private float lastSwingTime;
    private Transform rightArm;
    private int swingCount = 0;
    private float currentTime = 0;
    private float duration = 3f;

    void Start()
    {
        animator = link.GetComponent<Animator>();
        
        lastSwingTime = swingCoolDown; //Turned to positive for first swing
        
        rightArm = transform.parent.parent;
    }

    private void Update() {  
        if(swingCount != 0) {
            currentTime += Time.deltaTime;
            if (currentTime > swingCoolDown)
            {
                animator.SetLayerWeight(1, 0);
                animator.SetInteger("SwingNr", 0);
                swingCount = 0;
                currentTime = 0;
            }
        }
        
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


    public void AttackSwing() { // 3 hit combo attack
        attack = true;
        float currentTime = Time.time;
        animator.SetLayerWeight(1,1);
        swingCount += 1;
        animator.SetInteger("SwingNr",swingCount); //Triggers animation
        //Debug.Log("Swing count " + swingCount);
        switch (swingCount)
        {   
            case 1:
                animator.Play("SwingOne", 1);
                break;
            case 2:
                animator.Play("SwingTwo", 1);
                break;
            default:

                break;
        }
        Debug.Log("Swing count: " + swingCount);


        if (currentTime - lastSwingTime > swingCoolDown) { //if between currentTime and last attack > AttackWindow -> reset timer
            lastSwingTime = currentTime;
            swingCount = 0;
            animator.SetInteger("SwingNr", swingCount);
            animator.SetLayerWeight(1,0); //Close layer
            Debug.Log("Reset!");
            //attack = false;
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
            
            if(other.GetComponent<Shatter>() != null ) {
                other.GetComponent<Health>().takeDamage(1);
                Debug.Log("BUSH BE GONE!");
            }
        }
        
    }
}