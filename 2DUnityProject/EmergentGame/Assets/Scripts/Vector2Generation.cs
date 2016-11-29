using UnityEngine;
using System.Collections;

public class Vector2Generation : MonoBehaviour {

    public GameObject dirtBGPrefab;
    public GameObject stoneBGPrefab;

    public float maxBGX;
    public float maxBGY;

    public float Variable1 = 0;
    public float Variable2 = 0;
    public float Variable3 = 0;

    //private Vector2 backgroundSize;

    // Use this for initialization
    void Start () {

        GroundPatternGeneration();

        //NoiseGeneration(Variable1, Variable2, Variable3);


    }
	
	// Update is called once per frame
	void Update () {

        
    }

/*    void NoiseGeneration(float v1, float v2, float v3)
    {
        backgroundSize = new Vector2(maxBGX, maxBGY);

        private float noise = 0;

        noise =
            (
            Mathf.PerlinNoise(backgroundSize.x * v1, backgroundSize.y * v1) * 0.5f
            + Mathf.PerlinNoise(backgroundSize.x * v2, backgroundSize.y * v2) * 1.3f
            + Mathf.PerlinNoise(backgroundSize.x * v3, backgroundSize.y * v3) * 0.6f

            );
    }
    */

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
            for (int x = 0; x < 30; x++)
            {
                float newX = xStart + width * x;
                float newY = yStart + height * y;

                float noise = Mathf.PerlinNoise(x / 10.0f, y / 10.0f);

                if (noise > 0.4f)
                {
                    Instantiate(dirtBGPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(stoneBGPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
                }

            }
        }

        

    }
}
