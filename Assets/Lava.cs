using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != null)
        {
           
            other.GetComponent<Health>().takeDamage(20);
            
        }
    }
   
}
