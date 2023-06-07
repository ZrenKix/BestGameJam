using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    GameObject burDörr;
    GameObject vakter;

    private void OnCollisionEnter(Collision collision) {if(collision.gameObject == burDörr && vakter == null) burDörr.SetActive(false);}

}
