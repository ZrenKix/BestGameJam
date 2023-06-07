using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDebris : MonoBehaviour
{
    float duration = 5f;
    float timer = 0;

    public void Clear() {
        Destroy(gameObject);
        timer = 0; 
    }

    private void Update() {
        if(isActiveAndEnabled) {
            timer += Time.deltaTime;
        }

        if(timer > duration) {
            Clear();
        }
    }
}
