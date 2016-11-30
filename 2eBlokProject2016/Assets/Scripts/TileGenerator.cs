using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour {

    public GameObject dirtBGPrefab;
    public GameObject stoneBGPrefab;

    public GameObject cloudBlockPrefab;

    public GameObject dirtBlockPrefab;
    public GameObject stoneBlockPrefab;

    public GameObject backgroundTileStorage;
    public GameObject levelBlockStorage;

    public float stoneMin;
    public float stoneMax;

    public float cloudMin;
    public float cloudMax;

    //private Vector2 backgroundSize;

    // Use this for initialization
    void Start () {

        GroundPatternGeneration();
        SkyPatternGeneration();

        //NoiseGeneration(Variable1, Variable2, Variable3);


    }
	
	// Update is called once per frame
	void Update () {

        
    }

    void SkyPatternGeneration()
    {
        var renderer = cloudBlockPrefab.GetComponent<Renderer>();

        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;

        float xStart = 0.5f;
        float yStart = 0.5f;

        for (int y = 12; y < 20; y++)
        {
            for (int x = 0; x < 35; x++)
            {
                float newX = xStart + width * x;
                float newY = yStart + height * y;

                float noise = Mathf.PerlinNoise(x / 10.0f, y / 10.0f) * Random.Range(cloudMin, cloudMax);

                if (noise > 0.4f)
                {
                    Instantiate(cloudBlockPrefab, new Vector3(newX, newY, 0), Quaternion.identity, levelBlockStorage.transform);
                }

            }
        }
    }


    void GroundPatternGeneration()
    {

        var renderer = dirtBGPrefab.GetComponent<Renderer>();

        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;

        Debug.Log(width);

        float xStart = 0.5f;
        float yStart = 0.5f;

        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 40; x++)
            {
                float newX = xStart + width * x;
                float newY = yStart + height * y;

                float noise = Mathf.PerlinNoise(x / 10.0f, y / 10.0f) * Random.Range(stoneMin, stoneMax);

                if (noise > 0.4f)
                {
                    Instantiate(dirtBGPrefab, new Vector3(newX, newY, 0), Quaternion.identity, backgroundTileStorage.transform);
                    Instantiate(dirtBlockPrefab, new Vector3(newX, newY, 0), Quaternion.identity, levelBlockStorage.transform);
                }
                else if (y < 4 && noise < 0.4f)
                {
                    Instantiate(stoneBGPrefab, new Vector3(newX, newY, 0), Quaternion.identity, backgroundTileStorage.transform);
                    Instantiate(stoneBlockPrefab, new Vector3(newX, newY, 0), Quaternion.identity, levelBlockStorage.transform);
                }
                else if(y <= 4 && noise < 0.4f)
                {
                    Instantiate(dirtBGPrefab, new Vector3(newX, newY, 0), Quaternion.identity, backgroundTileStorage.transform);
                    Instantiate(dirtBlockPrefab, new Vector3(newX, newY, 0), Quaternion.identity, levelBlockStorage.transform);
                }

            }
        }

        

    }
}
