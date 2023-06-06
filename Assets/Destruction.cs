using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject mesh;

    float cubeWidth;
    float cubeHeight;
    float cubeDepth;

    public float cubeScale = 0.3f;

    private void Start()
    {
        cubeWidth = transform.localScale.z;
        cubeHeight = transform.localScale.y;
        cubeDepth = transform.localScale.x;
    }
}
