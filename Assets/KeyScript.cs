using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    GameObject burD�rr;
    [SerializeField]
    GameObject vakter;

    private void OnCollisionEnter(Collision collision) {if(collision.gameObject == burD�rr && vakter == null) burD�rr.SetActive(false);}

}
