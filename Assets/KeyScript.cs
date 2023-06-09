using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameObject cageDoor;
    private GameObject vakter;
    private ZeldaAnimation zeldaAnimation;
    //private GameObject link;
    [SerializeField] private BgMusicScript bgMusic;
    private UITimer timer;
   

    private void Start()
    {
        bgMusic = GameObject.Find("BgMusic").GetComponent<BgMusicScript>();
        cageDoor = GameObject.Find("CageDoor");
        vakter = GameObject.Find("Vakter");
       // link = GameObject.Find("Link");
        zeldaAnimation = GameObject.Find("Zelda").GetComponent<ZeldaAnimation>();
        timer = GameObject.Find("Timer").GetComponent<UITimer>();

    }

    private void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject == cageDoor && vakter == null)
        {
            
            cageDoor.SetActive(false);
            zeldaAnimation.enabled = true;
            bgMusic.playWinMusic();
            timer.StopTimer();

        }
    }

}
