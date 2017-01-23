using UnityEngine;
using System.Collections;

public class TreeStats : MonoBehaviour {

    public int treeHP = 10;

    private bool rootActive = true;

    [SerializeField]
    private GameObject woodBlock;

    [SerializeField]
    private GameObject blocks;

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

            Instantiate(woodBlock, gameObject.transform.position + new Vector3(0, 1, 0.5f), Quaternion.identity, blocks.transform);
            Instantiate(woodBlock, gameObject.transform.position + new Vector3(0, 3, 0.5f), Quaternion.identity, blocks.transform);
            Instantiate(woodBlock, gameObject.transform.position + new Vector3(0, 5, 0.5f), Quaternion.identity, blocks.transform);
            Instantiate(woodBlock, gameObject.transform.position + new Vector3(0, 7, 0.5f), Quaternion.identity, blocks.transform);
            Instantiate(woodBlock, gameObject.transform.position + new Vector3(0, 9, 0.5f), Quaternion.identity, blocks.transform);

            
            gameObject.SetActive(false);
            
            
        }

    }

}
