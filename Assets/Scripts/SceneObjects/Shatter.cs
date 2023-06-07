using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject crackedPot;
    public void Destruct() {
        Debug.Log("SHATTER!");
        crackedPot.SetActive(true);
        Instantiate(crackedPot, transform.position, transform.rotation);
    }
}
