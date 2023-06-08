using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScriptGuard : MonoBehaviour
{
   [SerializeField] GameObject textObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword")) {
            StartCoroutine("ShowText");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
    }

    IEnumerator ShowText()
    {
        textObject.SetActive(true);
        yield return new WaitForSeconds(5);
        textObject.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
