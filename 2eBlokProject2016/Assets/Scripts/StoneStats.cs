using UnityEngine;
using System.Collections;

public class StoneStats : MonoBehaviour {

    public int stoneHP = 4;
    public int stoneATK = 3;
    
    // Use this for initialization
    void Start ()
    {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        DirtStats otherDirtValues = other.gameObject.GetComponent<DirtStats>();
        CloudStats otherCloudValues = other.gameObject.GetComponent<CloudStats>();
        StoneStats otherStoneValues = other.gameObject.GetComponent<StoneStats>();
        TreeStats otherTreeValues = other.gameObject.GetComponent<TreeStats>();

        if (RaycastScript.isThrown == true && gameObject.tag == "PickedUpObject")
        {
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

            if (other.gameObject.tag == "Player")
            {
                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player2")
            {
                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player3")
            {
                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player4")
            {
                gameObject.tag = "Stone";
                RaycastScript.isThrown = false;
            }
        }

        
    }

    // Update is called once per frame
    void FixedUpdate () {
	    
        if (stoneHP <= 0)
        {
            Destroy(gameObject);
        }

	}
    
}
