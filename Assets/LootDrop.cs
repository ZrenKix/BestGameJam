using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{

    public static LootDrop Instance { get; set; }

    [SerializeField]
    GameObject[] prefabs;
    private int weight = 0;
    

    public void DropLoot()
    {
        weight = Random.Range(1, 100);
        if(weight == 1)
        {
            Instantiate(prefabs[0], transform);
        }
        else if(weight <= 50)
        {
            Instantiate(prefabs[1], transform);
        }
        else
        {
            Instantiate(prefabs[2], transform);
        }
    }


}
