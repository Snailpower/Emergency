using UnityEngine;
using System.Collections;

public class TreeStats : MonoBehaviour {

    public int treeHP = 10;

    private bool rootActive = true;

    private Rigidbody2D rigidbodyComponent;
    //public RaycastScript playerController;

    // Use this for initialization
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();


        //playerController = GetComponent<RaycastScript>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dirt" && rootActive == true)
        {
            other.gameObject.tag = "TreeRoot";
        }
        else if (other.gameObject.tag == "TreeRoot" && rootActive == false)
        {
            other.gameObject.tag = "Dirt";
        }
    }



    // Update is called once per frame
    void Update()
    {

        //gameObject.transform.position.z(transform.position.x, transform.position.y, 0.0f);

        if (treeHP <= 0)
        {
            rigidbodyComponent.isKinematic = false;


            rootActive = false;
            
        }

    }

}
