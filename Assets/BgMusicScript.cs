using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusicScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip standardMusic;
    [SerializeField] private AudioClip winMusic;
  
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
   
    public void playWinMusic()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(winMusic);
        Debug.Log("nu borde winmusic spelas");
    }


}
