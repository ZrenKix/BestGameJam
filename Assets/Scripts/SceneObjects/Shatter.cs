using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject crackedPot;
    public GameObject crackedBush;
    public void DestructPot() {
        Debug.Log("SHATTER!");
        crackedPot.SetActive(true);
        Instantiate(crackedPot, transform.position, transform.rotation);
    }

    public void DestructBush() {
        Debug.Log("SHATTER!");
        crackedBush.SetActive(true);
        Instantiate(crackedBush, transform.position, transform.rotation);
    }
}
