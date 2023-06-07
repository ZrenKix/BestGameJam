using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject crackedPot;
    private float duration = 5f;
    private float time = 0f;
    public void Destruct() {
        Debug.Log("SHATTER!");
        Instantiate(crackedPot, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void ClearDebris() {
       
    }

    private void Update() {
        time += Time.deltaTime;
        if(time > duration) {
            crackedPot.gameObject.SetActive(false);
        }
    }
}
