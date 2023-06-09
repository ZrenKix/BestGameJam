using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokstavBox : MonoBehaviour
{
    private ByggString byggString;

    private void Start()
    {
        byggString = GameObject.Find("Username").GetComponent<ByggString>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            byggString.BuildString(name);
        }
    }

}
