using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject crackedPot;
    public GameObject crackedBush;
    public GameObject crackedRestartBtn;
    public void DestructPot() {
        crackedPot.SetActive(true);
        Instantiate(crackedPot, transform.position, transform.rotation);
    }

    public void DestructBush() {
        crackedBush.SetActive(true);
        Instantiate(crackedBush, transform.position, transform.rotation);
    }

    public void DestructRestartBtn()
    {
        crackedRestartBtn.SetActive(true);
        Instantiate(crackedRestartBtn, transform.position, transform.rotation);
    }
}
