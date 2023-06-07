using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    GameObject burDörr;
    [SerializeField]
    GameObject vakter;

    private void OnCollisionEnter(Collision collision) {if(collision.gameObject == burDörr && vakter == null) burDörr.SetActive(false);}

}
