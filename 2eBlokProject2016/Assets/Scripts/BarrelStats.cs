using UnityEngine;
using System.Collections;

public class BarrelStats : MonoBehaviour {

    public int barrelHP = 2;
    public bool exploded = false;

    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        DirtStats otherDirtValues = other.gameObject.GetComponent<DirtStats>();
        CloudStats otherCloudValues = other.gameObject.GetComponent<CloudStats>();
        StoneStats otherStoneValues = other.gameObject.GetComponent<StoneStats>();

        if (gameObject.tag == "PickedUpObject")
        {
            gameObject.GetComponent<BarrelStats>().barrelHP -= 2;
        }


    }


    // Update is called once per frame
    void Update()
    {

        //gameObject.transform.position.z(transform.position.x, transform.position.y, 0.0f);



        if (barrelHP <= 0)
        {
            exploded = true;
        }

    }
}