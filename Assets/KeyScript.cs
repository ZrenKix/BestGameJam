using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameObject burDörr;
    private GameObject vakter;

    private void Start()
    {
        burDörr = GameObject.Find("CageDoor");
        vakter = GameObject.Find("Vakter");
    }

    private void OnCollisionEnter(Collision collision) {if(collision.gameObject == burDörr && vakter == null) burDörr.SetActive(false);}

}
