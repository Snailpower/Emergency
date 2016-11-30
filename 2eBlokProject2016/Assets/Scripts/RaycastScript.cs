using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour {

    static public bool isThrown = false;

    private bool pickedUp = false;

    private GameObject PickedObject;

    private Vector2 ObjectPoint;

    private float distanceFromPlayer = 2.0f;
    private float throwForce = 2000.0f;

    private Rigidbody2D rigidbodyPickedObject;

    private StoneStats stoneBlocks;
    private CloudStats cloudBlocks;
    private DirtStats dirtBlocks;

    private KeyCode pickAndThrowInput;

    void Start()
    {
        if (this.gameObject.tag == "Player")
        {
            pickAndThrowInput = KeyCode.Space;
        }
        else if (this.gameObject.tag == "Player2")
        {
            pickAndThrowInput = KeyCode.Alpha1;
        }
    }

	// Update is called once per frame
	void Update () {
        ObjectPoint = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer);

        if (pickedUp == true)
        {
            PickedObject.transform.position = ObjectPoint;
        }

        Debug.Log(isThrown);

    }

    void FixedUpdate() {
        RaycastBottom();

    }

    void RaycastBottom()
    {
        if (Input.GetKeyDown(pickAndThrowInput))
        {
            //  First time when spacebar is pressed
            if (pickedUp == false) {
                PickUpObject();
            }

            //  second time spacebar is pressed
            else if (pickedUp == true) {
                ShootObject();
                isThrown = true;
            }
        }
    }

    void PickUpObject()
    {
        Vector2 raycastposition = new Vector2(transform.position.x, transform.position.y - 0.5f);

        RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.down, 40);

        Debug.DrawRay(raycastposition, Vector2.down, Color.red, 5);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Dirt" || hit.collider.gameObject.tag == "Stone" || hit.collider.gameObject.tag == "Cloud")    //  it works but it hits the player first
            {
                GameObject other = hit.collider.gameObject;

                PickedObject = other.gameObject;

                other.tag = "PickedUpObject";

                pickedUp = true;
            }
        }
    }

    void ShootObject()
    {
        rigidbodyPickedObject = PickedObject.GetComponent<Rigidbody2D>();  // Tom already has  a rigidbody
        rigidbodyPickedObject.isKinematic = false;

        rigidbodyPickedObject.AddForce(transform.right * throwForce);
        pickedUp = false;
    }
}
