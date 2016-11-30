using UnityEngine;
using System.Collections;

public class CloudStats : MonoBehaviour {

    public int cloudHP = 2;

    public int cloudATK = 0;

    public RaycastScript playerController;
    

    // Use this for initialization
    void Start ()
    {
        playerController = GetComponent<RaycastScript>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        DirtStats otherDirtValues = other.gameObject.GetComponent<DirtStats>();
        CloudStats otherCloudValues = other.gameObject.GetComponent<CloudStats>();
        StoneStats otherStoneValues = other.gameObject.GetComponent<StoneStats>();

        if (RaycastScript.isThrown == true && gameObject.tag == "PickedUpObject")
        {
            if (other.gameObject.tag == "Dirt")
            {
                otherDirtValues.dirtHP -= cloudATK;

                gameObject.tag = "Cloud";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Stone")
            {
                otherStoneValues.stoneHP -= cloudATK;

                gameObject.tag = "Cloud";
                RaycastScript.isThrown = false;
            }

            if (other.gameObject.tag == "Cloud")
            {
                otherCloudValues.cloudHP -= cloudATK;

                gameObject.tag = "Cloud";
                RaycastScript.isThrown = false;
            }
        }

        
    }
	
	// Update is called once per frame
	void Update () {
	    
        if (cloudHP <= 0)
        {
            Destroy(gameObject);
        }

	}
    
}
