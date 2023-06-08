using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] private Item items;
    [SerializeField] private Terrain terrain;

    private void FixedUpdate()
    {
        
    }

}



public class ItemObject : MonoBehaviour {
    

    [Serializable]
    public struct Item
    {
        private GameObject gameObject;
        private float spawnRate;
    }
}