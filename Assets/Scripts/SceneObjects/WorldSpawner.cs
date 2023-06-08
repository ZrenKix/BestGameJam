using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Terrain terrain;

    // Terrain values
    private int terrainWidth;
    private int terrainLength;
    private int terrainPosX;
    private int terrainPosZ;

    // Limit spawn pos
    public int posMin;
    public int posMax;

    void Start()
    {
        terrainWidth = (int)terrain.terrainData.size.x;
        terrainLength = (int)terrain.terrainData.size.z;
        terrainPosX = (int)terrain.transform.position.x;
        terrainPosZ = (int)terrain.transform.position.z;
    }

    void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].currentAmount < items[i].maxAmount)
            {
                PlaceObject(i);
            }
            else
            {
                Debug.Log("Generate objects complete!");
            }
        }
    }

    void PlaceObject(int i)
    {
        int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
        int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
        float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
        if (posy < posMax && posy > posMin)
        {
            GameObject newObject = (GameObject)Instantiate(items[i].gameObject, new Vector3(posx, 0.2f, posz), Quaternion.identity);
            items[i].currentAmount++;
        }
        else
        {
            PlaceObject(i);
        }
    }
}

[Serializable]
public struct Item
{
    public GameObject gameObject;
    public int maxAmount;
    public int currentAmount;
}