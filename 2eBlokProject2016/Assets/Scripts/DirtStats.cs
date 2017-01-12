using UnityEngine;
using System.Collections;

public class DirtStats : MonoBehaviour {

    public int dirtHP = 1;

    public int dirtATK = 1;

    //public RaycastScript playerController;

    // Use this for initialization
    void Start()
    {
        //playerController = GetComponent<RaycastScript>();

        
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        DirtStats otherDirtValues = other.gameObject.GetComponent<DirtStats>();
        CloudStats otherCloudValues = other.gameObject.GetComponent<CloudStats>();
        StoneStats otherStoneValues = other.gameObject.GetComponent<StoneStats>();
        TreeStats otherTreeValues = other.gameObject.GetComponent<TreeStats>();
        PlayerStats otherPlayerValues = other.gameObject.GetComponent<PlayerStats>();

        if (RaycastScript.isThrown == true && gameObject.tag == "PickedUpObject")
            {
            if (other.gameObject.tag == "Dirt")
            {
                otherDirtValues.dirtHP -= dirtATK;

                gameObject.tag = "Dirt";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Stone")
            {
                otherStoneValues.stoneHP -= dirtATK;

                gameObject.tag = "Dirt";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Cloud")
            {
                otherCloudValues.cloudHP -= dirtATK;

                gameObject.tag = "Dirt";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Tree")
            {
                otherTreeValues.treeHP -= dirtATK;

                gameObject.tag = "Dirt";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player")
            {
                otherPlayerValues.playerHP -= dirtATK;

                gameObject.tag = "Dirt";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player2")
            {
                otherPlayerValues.playerHP -= dirtATK;

                gameObject.tag = "Dirt";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player3")
            {
                otherPlayerValues.playerHP -= dirtATK;

                gameObject.tag = "Dirt";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Player4")
            {
                otherPlayerValues.playerHP -= dirtATK;

                gameObject.tag = "Dirt";
                RaycastScript.isThrown = false;
            }
        }

        
    }

	
	// Update is called once per frame
	void FixedUpdate () {

        //gameObject.transform.position.z(transform.position.x, transform.position.y, 0.0f);

        if(dirtHP <= 0)
        {
            Destroy(gameObject);
        }

	}

}
