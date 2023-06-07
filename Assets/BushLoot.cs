using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushLoot : MonoBehaviour
{


    public bool uppPlockad = false;
    public bool droppadAvParent = false;
    [SerializeField]
    GameObject[] prefabs;
    
   
  

    public void DropLootBush()
    {
        int weight = Random.Range(1, 100);
        if (weight < 51)
        {
            Instantiate(prefabs[0], transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }
        
    }



}
