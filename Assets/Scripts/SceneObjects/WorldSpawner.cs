using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Terrain terrain;

    private void FixedUpdate()
    {
        
    }
}

[Serializable]
public struct Item
{
    public GameObject gameObject;
    public float spawnRate;
}