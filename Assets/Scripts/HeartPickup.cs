using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    private int healthValue = 1;

    void Update()
    {
        if (transform.parent != null)
        {
            GameObject parentObject = transform.parent.gameObject;
            if (parentObject.tag.Equals("Player"))
            {
                parentObject.GetComponent<Health>().increaseHealth(healthValue);
                Destroy(gameObject);
            }
        }
    }
}
