using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour {

    static public bool isThrown = false;

    private bool pickedUp = false;

    private GameObject PickedObject;

    private Vector2 ObjectPoint;    // the point where the picked-up block goes to
    public Vector2 diggingObjectPointLeft; // digging down left raycast use this point
    private Vector2 diggingObjectPointRight;    //  digging down right raycast use this point
    private Vector2 diggingObjectPointHorizontal; // digging left or right use this point

    private float distanceFromPlayer = 2.0f;
    private float throwForce = 2000.0f;
    private float rayLength = 100;
    private float lenghtFromPlayerHorizontal = 0.2f;
    private float lengthFromPlayerDigging = 0.5f;

    private Rigidbody2D rigidbodyPickedObject;
<<<<<<< HEAD
    
    private KeyCode pickAndThrowInput;
    private KeyCode holdToDig;
=======

    private KeyCode pickAndThrowInput;

>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
    
    void Start()
    {
        if (this.gameObject.tag == "Player")
        {
            pickAndThrowInput = KeyCode.Space;
            holdToDig = KeyCode.B;
        }
        else if (this.gameObject.tag == "Player2")
        {
            pickAndThrowInput = KeyCode.Alpha1;
            holdToDig = KeyCode.Alpha2;
        }
    }

	// Update is called once per frame
	void Update () {
        RaycastBottom();
        SettingPoints();
        CheckPickedUp();
        Digging();
    }

    void CheckPickedUp()
    {
        if (pickedUp == true)
        {
            PickedObject.transform.position = ObjectPoint;
        }
    }
    
    void SettingPoints()
    {
        ObjectPoint = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer);

<<<<<<< HEAD
        diggingObjectPointLeft = new Vector2(transform.position.x + distanceFromPlayer, transform.position.y + distanceFromPlayer);
        diggingObjectPointRight = new Vector2(transform.position.x - distanceFromPlayer, transform.position.y + distanceFromPlayer);

        diggingObjectPointHorizontal = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer + 5);
=======
        Digging();

        Debug.Log(isThrown);
>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
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

        RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.down, rayLength);

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
<<<<<<< HEAD
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(holdToDig))
=======
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.B))
>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
        {
            Debug.Log("It is digging down");
            DoDigging();
        }

<<<<<<< HEAD
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(holdToDig))
=======
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.B))
>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
        {
            DoDiggingLeft();
        }

<<<<<<< HEAD
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(holdToDig))
=======
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.B))
>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
        {
            DoDiggingRight();
        }
    }

    void DoDiggingLeft()
    {
        // cast one raycast to the left
        Vector2 raycastToLeft = new Vector2(transform.position.x - lenghtFromPlayerHorizontal, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(raycastToLeft, Vector2.left, 10);

        Debug.DrawRay(raycastToLeft, Vector2.left, Color.green, 5);

        if (hit.collider != null)
        {
<<<<<<< HEAD
            if(hit.collider.gameObject.tag == "Stone" || hit.collider.gameObject.tag == "Dirt")
=======
            if(hit.collider.gameObject.tag == "Dirt" || hit.collider.gameObject.tag == "Stone")
>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
            {
                // change position
                GameObject other = hit.collider.gameObject;
                other.transform.position = diggingObjectPointHorizontal;
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce);
                other.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    void DoDiggingRight()
    {
        //  cast one raycast to the right
        Vector2 raycastToRight = new Vector2(transform.position.x + lenghtFromPlayerHorizontal, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(raycastToRight, Vector2.right, 10);

        Debug.DrawRay(raycastToRight, Vector2.right, Color.green, 5);

        if (hit.collider != null)
        {
<<<<<<< HEAD
            if (hit.collider.gameObject.tag == "Stone" || hit.collider.gameObject.tag == "Dirt")
=======
            if (hit.collider.gameObject.tag == "Dirt" || hit.collider.gameObject.tag == "Stone")
>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
            {
                GameObject other = hit.collider.gameObject;
                other.transform.position = diggingObjectPointHorizontal;
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce);
                other.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    void DoDigging()
    {
        // shoots two raycast downwards and the object it hits will be positioned above the player and shoot upwards
        Vector2 raycastPositionRight = new Vector2(transform.position.x + lengthFromPlayerDigging, transform.position.y - 0.5f);
        Vector2 raycastPositionLeft = new Vector2(transform.position.x - lengthFromPlayerDigging, transform.position.y - 0.5f);

        RaycastHit2D hitRight = Physics2D.Raycast(raycastPositionRight, Vector2.down, 40);
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastPositionLeft, Vector2.down, 40);

        Debug.DrawRay(raycastPositionRight, Vector2.down, Color.yellow, 5);
        Debug.DrawRay(raycastPositionLeft, Vector2.down, Color.yellow, 5);

        // Right raycast
        if (hitRight.collider != null)
        {
<<<<<<< HEAD
            if (hitRight.collider.gameObject.tag == "Stone" || hitRight.collider.gameObject.tag == "Dirt")    //  it works but it hits the player first
            {
                GameObject other = hitRight.collider.gameObject;

                other.transform.position = diggingObjectPointLeft; // change position
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1);

                Debug.Log("RIGHT raycast");
=======
            if (hitRight.collider.gameObject.tag == "Dirt" || hitRight.collider.gameObject.tag == "Stone")    //  it works but it hits the player first
            {
                GameObject other = hitRight.collider.gameObject;

                other.transform.position = ObjectPoint; // change position
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce);
                other.GetComponent<Rigidbody2D>().isKinematic = false;
>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
            }
        }
        //  Left raycast
        if (hitLeft.collider != null)
        {
<<<<<<< HEAD
            if (hitLeft.collider.gameObject.tag == "Stone" || hitLeft.collider.gameObject.tag == "Dirt")    //  it works but it hits the player first
            {
                GameObject other = hitRight.collider.gameObject;

                other.transform.position = diggingObjectPointRight; // change position
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1);

                Debug.Log("LEFT raycast");
=======
            if (hitLeft.collider.gameObject.tag == "Dirt" || hitRight.collider.gameObject.tag == "Stone")    //  it works but it hits the player first
            {
                GameObject other = hitRight.collider.gameObject;

                other.transform.position = ObjectPoint; // change position
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce);
                other.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            else
            {

>>>>>>> 3a7d196622c5be25858c5e3e45cb301786f177c9
            }
        }
    }
}
