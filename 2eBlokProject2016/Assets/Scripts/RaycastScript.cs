using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour {

    static public bool isThrown = false;

    private bool pickedUp = false;

    private GameObject PickedObject;

    private Vector2 ObjectPoint;
    private Vector2 digginObjectPoint;

    private float distanceFromPlayer = 2.0f;
    private float throwForce = 2000.0f;

    private Rigidbody2D rigidbodyPickedObject;

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
        digginObjectPoint = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer + 5);

        if (pickedUp == true)
        {
            PickedObject.transform.position = ObjectPoint;
        }

        Digging();

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

    void Digging()
    {
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.B))
        {
            DoDigging();
        }

        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.B))
        {
            DoDiggingLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.B))
        {
            DoDiggingRight();
        }
    }

    void DoDiggingLeft()
    {
        // cast one raycast to the left
        Vector2 raycastToLeft = new Vector2(transform.position.x - 0.2f, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(raycastToLeft, Vector2.left, 10);

        Debug.DrawRay(raycastToLeft, Vector2.left, Color.green, 5);

        if (hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Dirt" || hit.collider.gameObject.tag == "Stone")
            {
                // change position
                GameObject other = hit.collider.gameObject;
                other.transform.position = digginObjectPoint;
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce);
                other.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    void DoDiggingRight()
    {
        //  cast one raycast to the right
        Vector2 raycastToRight = new Vector2(transform.position.x + 0.2f, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(raycastToRight, Vector2.right, 10);

        Debug.DrawRay(raycastToRight, Vector2.right, Color.green, 5);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Dirt" || hit.collider.gameObject.tag == "Stone")
            {
                GameObject other = hit.collider.gameObject;
                other.transform.position = digginObjectPoint;
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce);
                other.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    void DoDigging()
    {
        // shoots two raycast downwards and the object it hits will be positioned above the player and shoot upwards
        Vector2 raycastPositionRight = new Vector2(transform.position.x, transform.position.y - 0.5f);
        Vector2 raycastPositionLeft = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f);

        RaycastHit2D hitRight = Physics2D.Raycast(raycastPositionRight, Vector2.down, 40);
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastPositionLeft, Vector2.down, 40);

        Debug.DrawRay(raycastPositionRight, Vector2.down, Color.yellow, 5);
        Debug.DrawRay(raycastPositionLeft, Vector2.down, Color.yellow, 5);

        // Right raycast
        if (hitRight.collider != null)
        {
            if (hitRight.collider.gameObject.tag == "Dirt" || hitRight.collider.gameObject.tag == "Stone")    //  it works but it hits the player first
            {
                GameObject other = hitRight.collider.gameObject;

                other.transform.position = ObjectPoint; // change position
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce);
                other.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
        //  Left raycast
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.gameObject.tag == "Dirt" || hitRight.collider.gameObject.tag == "Stone")    //  it works but it hits the player first
            {
                GameObject other = hitRight.collider.gameObject;

                other.transform.position = ObjectPoint; // change position
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce);
                other.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            else
            {

            }
        }
    }
}
