using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    GameObject parentObject;
    Health healthScript;
    [SerializeField] private int healthValue = 1;

    void Update()
    {
      parentObject = transform.parent.gameObject;
        if (parentObject.tag.Equals("Player")) {
          parentObject.GetComponent<Health>().increaseHealth(healthValue);
            
        }
    }
}
