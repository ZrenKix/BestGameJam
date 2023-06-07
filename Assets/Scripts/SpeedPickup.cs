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

    void Update()
    { if (!hasPickedUp)
        {
            try
            {
                parentObject = transform.parent.gameObject;
                if (parentObject.tag.Equals("Player"))
                {
                    //hej
                    playerControl = parentObject.GetComponent<PlayerControll>();
                    playerControl.sprintSpeed += sprintSpeedIncrease;
                    playerControl.walkSpeed += walkSpeedIncrease;
                    hasPickedUp = true;
                    StartCoroutine("RemoveLiquid");
                    StartCoroutine("DropAfterTime");
                    StartCoroutine("DestroyPotionAfterTime");

                }
            }
            catch
            {

            }

        }



    }

    IEnumerator DestroyPotionAfterTime()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
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
