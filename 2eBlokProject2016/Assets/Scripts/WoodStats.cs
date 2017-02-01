using UnityEngine;
using System.Collections;

public class WoodStats : MonoBehaviour {

    public int woodHP = 5;

    public int woodATK = 2;

    private ParticleManagerScript particleManager;

    [SerializeField]
    private GameObject particleManagerObject;

    // Use this for initialization
    void Start () {
        particleManager = particleManagerObject.GetComponent<ParticleManagerScript>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        DirtStats otherDirtValues = other.gameObject.GetComponent<DirtStats>();
        CloudStats otherCloudValues = other.gameObject.GetComponent<CloudStats>();
        StoneStats otherStoneValues = other.gameObject.GetComponent<StoneStats>();
        TreeStats otherTreeValues = other.gameObject.GetComponent<TreeStats>();
        WoodStats otherWoodValues = other.gameObject.GetComponent<WoodStats>();
        PlayerStats otherPlayerValues = other.gameObject.GetComponent<PlayerStats>();
        BarrelStats otherBarrelValues = other.gameObject.GetComponent<BarrelStats>();

        if (gameObject.tag == "PickedUpObject")
        {
            particleManager.SpawnBigSpark(this.transform.position);

            if (other.gameObject.tag == "Dirt")
            {
                otherDirtValues.dirtHP -= woodATK;

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Stone")
            {
                otherStoneValues.stoneHP -= woodATK;

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Cloud")
            {
                otherCloudValues.cloudHP -= woodATK;

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Tree")
            {
                otherTreeValues.treeHP -= woodATK;

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Wood")
            {
                otherTreeValues.treeHP -= woodATK;

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Barrel")
            {
                otherBarrelValues.barrelHP -= woodATK;

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "PlacedObject")
            {
                otherTreeValues.treeHP -= woodATK;

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player")
            {
                otherPlayerValues.TakeDamage(woodATK);

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player2")
            {
                otherPlayerValues.TakeDamage(woodATK);

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player3")
            {
                otherPlayerValues.TakeDamage(woodATK);

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player4")
            {
                otherPlayerValues.TakeDamage(woodATK);

                gameObject.tag = "Wood";
                RaycastScript.isThrown = false;
            }
        }


    }

    // Update is called once per frame
    void Update () {

        if (gameObject.tag == "PlacedObject")
        {
            gameObject.tag = "Wood";
        }

        if (woodHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
