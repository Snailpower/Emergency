using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour {

    static public bool isThrown = false;
    
    private GameObject PickedObject;
    private GameObject referenceExamplePutDown;

    private Vector2 ObjectPoint;    // the point where the picked-up block goes to
    private Vector2 putDownPoint;   // the point before the player where the block can be putt down
    private Vector2 raycastposition;    //  the position from where the ray is cast

    private float distanceFromPlayer = 2.0f;
    private float throwForce = 2000.0f;
    private float rayLength = 4;

    private float lenghtFromPlayerHorizontal = 0.2f;

    private float heightBlockPutDown = 0.8f;
    private float distanceBlockPutDown = 2.0f;

    private Rigidbody2D rigidbodyPickedObject;
    private MovingScript movingScriptVariable;
    
    private KeyCode pickAndThrowInput;

    private bool isGrounded;
    private bool goingRight;
    private bool pickedUp = false;
    private bool puttingItDown = false;
    private bool inHand = false;

    void Start()
    {
        raycastposition = new Vector2(transform.position.x, transform.position.y - 0.5f);
        
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
        isGrounded = this.GetComponent<MovingScript>().isGrounded;  // checks if the player is on the surface
        goingRight = this.GetComponent<MovingScript>().goingRight;  // gets the variable from the movingscript and checks the direction of the player

        if(puttingItDown == true)
        {
            PickedObject.transform.position = putDownPoint;
        }
        
        AdaptPutDownPoint();
        putDownObject();
        RaycastBottom();
        SettingPoints();
        CheckPickedUp();
    }

    void AdaptPutDownPoint()
    {
        //  changes the putDownPoint based on the direction of the player
        if (goingRight == true)
        {
            putDownPoint = new Vector2(transform.position.x + distanceBlockPutDown, transform.position.y + heightBlockPutDown);  // updates the point before the player where the object can be put
        }
        else if (goingRight == false)
        {
            putDownPoint = new Vector2(transform.position.x - distanceBlockPutDown, transform.position.y + heightBlockPutDown);  // updates the point before the player where the object can be put
        }
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
    }

    void putDownObject()
    {
        // when key is hold -> show location
        // When key is released -> put object on that location. 
        //  pickedUpObject.transform.position = show object
        //  cannot pick up object again because the tag is changed and it doesn't move because to non-kinematic

        // maybe check if it has an object
        //  shows the location

        if(inHand == true)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                puttingItDown = true;
                pickedUp = false;
                
                PickedObject.transform.position = putDownPoint;
            }
            //  puts the object down
            if (Input.GetKeyUp(KeyCode.N))
            {
                pickedUp = false;   //  TODO = maybe unneccesary
                puttingItDown = false;
                

                PickedObject.transform.position = putDownPoint;
                PickedObject = null;
                inHand = false;
            }
        }
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

        if (hit.collider != null)
        {
            if (isGrounded && (hit.collider.gameObject.tag == "Dirt" || 
                    hit.collider.gameObject.tag == "Stone" ||
                    hit.collider.gameObject.tag == "Cloud"))    //  it works but it hits the player first
            {
                GameObject other = hit.collider.gameObject;
                PickedObject = other.gameObject;

                other.tag = "PickedUpObject";
                pickedUp = true;
                inHand = true;
            }
        }
        else if (hit.collider == null)
        {
            raycastposition = new Vector2(transform.position.x + 0.2f, transform.position.y - 0.5f);
            if(movingScriptVariable.isGrounded)
            {
                PickUpObject();
            }
        }
        else
        {
            raycastposition = new Vector2(transform.position.x - 0.2f, transform.position.y - 0.5f);
            if (movingScriptVariable.isGrounded)
            {
                PickUpObject();
            }
        }
    }

    void ShootObject()
    {
        rigidbodyPickedObject = PickedObject.GetComponent<Rigidbody2D>();  // Tom already has  a rigidbody
        rigidbodyPickedObject.isKinematic = false;

        rigidbodyPickedObject.AddForce(transform.right * throwForce);
        rigidbodyPickedObject = null;
        pickedUp = false;
    }
}
