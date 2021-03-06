﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoneStats : MonoBehaviour {

    public int stoneHP = 4;
    public int stoneATK = 3;

    private ParticleManagerScript particleManager;

    [SerializeField]
    private GameObject particleManagerObject;

    // Use this for initialization
    void Start ()
    {
        particleManager = particleManagerObject.GetComponent<ParticleManagerScript>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        DirtStats otherDirtValues = other.gameObject.GetComponent<DirtStats>();
        CloudStats otherCloudValues = other.gameObject.GetComponent<CloudStats>();
        StoneStats otherStoneValues = other.gameObject.GetComponent<StoneStats>();
        TreeStats otherTreeValues = other.gameObject.GetComponent<TreeStats>();
        PlayerStats otherPlayerValues = other.gameObject.GetComponent<PlayerStats>();
        BarrelStats otherBarrelValues = other.gameObject.GetComponent<BarrelStats>();

        if (gameObject.tag == "PickedUpObject")
        {
            particleManager.SpawnBigSpark(this.transform.position);

            if (other.gameObject.tag == "Dirt")
            {
                otherDirtValues.dirtHP -= stoneATK;

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Stone")
            {
                otherStoneValues.stoneHP -= stoneATK;

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Cloud")
            {
                otherCloudValues.cloudHP -= stoneATK;

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Tree")
            {
                otherTreeValues.treeHP -= stoneATK;

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Wood")
            {
                otherTreeValues.treeHP -= stoneATK;

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Barrel")
            {
                otherBarrelValues.barrelHP -= stoneATK;

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player")
            {
                otherPlayerValues.TakeDamage(stoneATK);

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player2")
            {
                otherPlayerValues.TakeDamage(stoneATK);

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player3")
            {
                otherPlayerValues.TakeDamage(stoneATK);

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player4")
            {
                otherPlayerValues.TakeDamage(stoneATK);

                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }
        }

        
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (gameObject.tag == "PlacedObject")
        {
            gameObject.tag = "Stone";
        }


        if (stoneHP <= 0)
        {
            Destroy(gameObject);
        }

	}
    
}
