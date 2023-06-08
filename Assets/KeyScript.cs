using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameObject burDörr;
    private GameObject vakter;
    private ZeldaAnimation zeldaAnimation;
    //private GameObject link;
    [SerializeField] private BgMusicScript bgMusic;
   

    private void Start()
    {
        burDörr = GameObject.Find("CageDoor");
        vakter = GameObject.Find("Vakter");
       // link = GameObject.Find("Link");
        zeldaAnimation = GameObject.Find("Zelda").GetComponent<ZeldaAnimation>();

    }

    private void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject == burDörr && vakter == null)
        {
            bgMusic.playWinMusic();
            burDörr.SetActive(false);
            Debug.Log(zeldaAnimation.enabled);
            zeldaAnimation.enabled = true;
            Debug.Log(zeldaAnimation.enabled);
            
        }
    }

}
