using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{

    
    public bool uppPlockad = false;
    public bool droppadAvParent = false;
    [SerializeField]
    GameObject[] prefabs;
    private int weight = 0;
    AudioSource audioSource;
    [SerializeField] AudioClip crackSound;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(gameObject.GetComponentInParent<PlayerControll>() != null)
        {
            uppPlockad = true;
        }
        if (uppPlockad && gameObject.GetComponentInParent<PlayerControll>() == null)
        {
            droppadAvParent = true;
        }
    }

    public void DropLoot()
    {
        audioSource.PlayOneShot(crackSound);
        weight = Random.Range(1, 100);
        if(weight == 1)
        {
            Instantiate(prefabs[0], transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }
        else if(weight <= 50)
        {
            Instantiate(prefabs[1], transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }
        else
        {
            Instantiate(prefabs[2], transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (droppadAvParent)
        {
            gameObject.GetComponent<Health>().takeDamage(1);
        }
    }

}
