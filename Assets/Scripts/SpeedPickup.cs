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
}
