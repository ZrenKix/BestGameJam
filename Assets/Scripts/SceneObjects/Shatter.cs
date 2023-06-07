using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject crackedPot;
    private float duration = 5f;
    private float time;
    public void Destruct() {
        Debug.Log("SHATTER!");
        Instantiate(crackedPot, transform.position, transform.rotation);
        time = Time.time;

        if(time > duration) {
            crackedPot.gameObject.SetActive(false);
        }
        
    }

    public void ClearDebris() {
       
    }

    private void Update() {
        if(time != null) {
            time += Time.deltaTime;
        }
    }
}
