using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    GameObject parentObject;
    private bool hasPickedUp;
    PlayerControll playerControl;
    [SerializeField] private int walkSpeedIncrease = 1;
    [SerializeField] private int sprintSpeedIncrease = 1;
    [SerializeField] private GameObject liquid;
    [SerializeField] private GameObject lid;
    [SerializeField] private AudioClip drink;
    [SerializeField] private AudioSource audioSource;

    PlayerControll playerControll;

    private void Awake()
    {
        playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerControll>();
    }

    void Update()
    { if (!hasPickedUp)
        {
            try
            {
                parentObject = transform.parent.gameObject;
                if (parentObject.tag.Equals("Player"))
                {
                    playerControl = parentObject.GetComponent<PlayerControll>();
                    playerControl.sprintSpeed += sprintSpeedIncrease;
                    playerControl.walkSpeed += walkSpeedIncrease;
                    hasPickedUp = true;
                    audioSource.PlayOneShot(drink);
                    StartCoroutine("RemoveLiquid");
                    StartCoroutine("DropAfterTime");
                    StartCoroutine("Hidepotion");
                    StartCoroutine("StopSpeedBoost");
                }
            }
            catch
            {

            }

        }



    }

    IEnumerator StopSpeedBoost()
    {
        yield return new WaitForSeconds(6f);
        playerControl.sprintSpeed = 7;
        playerControl.walkSpeed = 4;
        Destroy(gameObject);
    }

    IEnumerator Hidepotion()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Collider>().enabled = false;
    }
    IEnumerator RemoveLiquid()
    {
        yield return new WaitForSeconds(0.4f);
        liquid.SetActive(false);
        lid.SetActive(false);
    }
    IEnumerator DropAfterTime()
    {
        yield return new WaitForSeconds(0.8f);
        playerControl.DropObject();

    }

}
