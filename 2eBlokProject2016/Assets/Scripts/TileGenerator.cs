﻿using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour {

    public GameObject dirtBGPrefab;
    public GameObject stoneBGPrefab;

    public GameObject cloudBlockPrefab;

    public GameObject barrelPrefab;

    public GameObject dirtBlockPrefab;
    public GameObject stoneBlockPrefab;

    public GameObject backgroundTileStorage;
    public GameObject levelBlockStorage;
    public GameObject barrelStorage;

    public GameObject treeStorage;

    public GameObject treePrefab;

    public float stoneMin;
    public float stoneMax;

    public float cloudMin;
    public float cloudMax;

    // Use this for initialization
    void Start () {

        GroundPatternGeneration();
        SkyPatternGeneration();
        ExplosiveGeneration();

    }
	
	// Update is called once per frame
	void Update () {

        
    }

    void ExplosiveGeneration()
    {
        var renderer = barrelPrefab.GetComponent<Renderer>();

        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;

        float xStart = 0.5f;
        float yStart = 0.5f;

        for (int y = 4; y <= 4; y++)
        {
            for (int x = -40; x < 87; x++)
            {
                float newX = xStart + width * x;
                float newY = yStart + height * y;

                float noise = Mathf.PerlinNoise(x, y / 10.0f) * Random.Range(cloudMin, cloudMax);

                if (noise > 0.5f)
                {
                    Instantiate(barrelPrefab, new Vector3(newX, newY, 0), Quaternion.identity, barrelStorage.transform);
                }

            }
        }
    }

    void SkyPatternGeneration()
    {
        var renderer = cloudBlockPrefab.GetComponent<Renderer>();

        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;

        float xStart = 0.5f;
        float yStart = 0.5f;

        for (int y = 12; y < 30; y++)
        {
            for (int x = -20; x < 67; x++)
            {
                float newX = xStart + width * x;
                float newY = yStart + height * y;

                float noise = Mathf.PerlinNoise(x / 10.0f, y / 10.0f) * Random.Range(cloudMin, cloudMax);

                if (noise > 0.4f)
                {
                    //Instantiate(cloudBlockPrefab, new Vector3(newX, newY, 0), Quaternion.identity, levelBlockStorage.transform);
                }

            }
        }
    }

    void GroundPatternGeneration()
    {

        var renderer = dirtBlockPrefab.GetComponent<Renderer>();

        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;

        float xStart = 0.5f;
        float yStart = 0.5f;

        for (int y = -11; y < 5; y++)
        {
            for (int x = -50; x < 97; x++)
            {
                float newX = xStart + width * x;
                float newY = yStart + height * y;

                float noise = Mathf.PerlinNoise(x / 10.0f, y / 10.0f) * Random.Range(stoneMin, stoneMax);

                if (noise > 0.4f)
                {
                    Instantiate(dirtBGPrefab, new Vector3(newX, newY, dirtBGPrefab.transform.position.z), Quaternion.identity, backgroundTileStorage.transform);
                    Instantiate(dirtBlockPrefab, new Vector3(newX, newY, 0), Quaternion.identity, levelBlockStorage.transform);
                }
                else if (y < 4 && noise < 0.4f)
                {
                    Instantiate(stoneBGPrefab, new Vector3(newX, newY, stoneBGPrefab.transform.position.z), Quaternion.identity, backgroundTileStorage.transform);
                    Instantiate(stoneBlockPrefab, new Vector3(newX, newY, 0), Quaternion.identity, levelBlockStorage.transform);
                }

                //Sets the first layer of the ground to dirt
                else if(y <= 4 && noise < 0.4f)
                {
                    Instantiate(dirtBGPrefab, new Vector3(newX, newY, dirtBGPrefab.transform.position.z), Quaternion.identity, backgroundTileStorage.transform);
                    Instantiate(dirtBlockPrefab, new Vector3(newX, newY, 0), Quaternion.identity, levelBlockStorage.transform);
                }

            }
        }

        

    }
}
