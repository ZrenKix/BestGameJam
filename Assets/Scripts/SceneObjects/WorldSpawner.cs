using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Terrain terrain;

    // Terrain values
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z

    void Start()
    {
        terrainWidth = (int)terrain.terrainData.size.x;
        terrainLength = (int)terrain.terrainData.size.z;
        terrainPosX = (int)terrain.transform.position.x;
        terrainPosZ = (int)terrain.transform.position.z;
    }

    void Update()
    {
        foreach (Item item in items)
        {
            if (item.currentAmount <= item.maxAmount)
            {
                item.increaseAmount();
                int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
                int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
                float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
                Instantiate(item.gameObject, new Vector3(posx, posy, posz), Quaternion.identity);
            } else
            {
                Debug.Log("Generate objects complete!");
            }
        }
    }
}

[Serializable]
public struct Item
{
    public GameObject gameObject;
    public int maxAmount;
    public int currentAmount;

    public void increaseAmount()
    {
        currentAmount++;
    }
}