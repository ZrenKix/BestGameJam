using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameObject burD�rr;
    private GameObject vakter;

    private void Start()
    {
        burD�rr = GameObject.Find("CageDoor");
        vakter = GameObject.Find("Vakter");
    }

    private void OnCollisionEnter(Collision collision) {if(collision.gameObject == burD�rr && vakter == null) burD�rr.SetActive(false);}

}
