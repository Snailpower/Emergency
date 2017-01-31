using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagerScript : MonoBehaviour
{

    public GameObject smallSparkPrefab;
    public GameObject bigSparkPrefab;
    public GameObject afterBurnerPrefab;
    public GameObject explosionPrefab;
    public GameObject damageSoundPrefab;
    
    //  for throwing
    public void SpawnSmallSpark(Vector2 position)
    {
        GameObject smallSpark = Instantiate(smallSparkPrefab, position, Quaternion.identity);
        Destroy(smallSpark, 1);
    }

    // for collision
    public void SpawnBigSpark(Vector2 position)
    {
        GameObject bigSpark = (GameObject)Instantiate(bigSparkPrefab, position, Quaternion.identity);
        Destroy(bigSpark, 1);
    }
    //  for placement
    public void SpawnAfterBurner(Vector2 position)
    {
        GameObject afterBurner = Instantiate(afterBurnerPrefab, position, Quaternion.identity);
        Destroy(afterBurner, 0.2f);
    }
    //  for explosion
    public void SpawnExplosion(Vector2 position)
    {
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        Destroy(explosion, 2f);
    }

    public void SpawnDamageSoundPlayer(Vector2 position)
    {
        GameObject soundObject = Instantiate(damageSoundPrefab, position, Quaternion.identity);
        Destroy(soundObject, 1);
    }
}
