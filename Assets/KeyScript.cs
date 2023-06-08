using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameObject burD�rr;
    private GameObject vakter;
    private ZeldaAnimation zeldaAnimation;
    private GameObject link;

    private void Start()
    {
        burD�rr = GameObject.Find("CageDoor");
        vakter = GameObject.Find("Vakter");
        link = GameObject.Find("Link");
        zeldaAnimation = GameObject.Find("Zelda").GetComponent<ZeldaAnimation>();

    }

    private void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject == burD�rr && vakter == null)
        {
            burD�rr.SetActive(false);
            Debug.Log(zeldaAnimation.enabled);
            zeldaAnimation.enabled = true;
            Debug.Log(zeldaAnimation.enabled);
        }
    }

}
