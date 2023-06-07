using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    Health health;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Health>() != null)
        {
            collision.collider.GetComponent<Health>().takeDamage(20);
        }
    }
}
