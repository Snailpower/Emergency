using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

    private Vector2 ObjectPoint;
    private float PlayerSpeed = 10;

    private float floatHeight;
    private float liftForce;
    private float damping;
    private Rigidbody2D rb2D;
    private bool pickedUp = false;

    private GameObject PickedObject;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementLeft();
        PlayerMovementRight();
        PlayerMovementUp();

        //  if true:  the object is above the player
        if(pickedUp == true) {
            PickedObject.transform.position = ObjectPoint * Time.deltaTime;
        }

        //  makes sure that the object is above the player all the time
        ObjectPoint = new Vector2(transform.position.x, transform.position.y);

        if(transform.position.x == ObjectPoint.x)
        {
            Debug.Log("X position is the same");
        }
        //Debug.Log("Player x: " + transform.position.x + " Player y: " + transform.position.y);
        //Debug.Log("ObjectPoint x: " + ObjectPoint.x + " ObjectPoint y: " + ObjectPoint.y);
    }

    void FixedUpdate()
    {
        RaycastBottom();
    }

    void PlayerMovementRight()
    {
        //  makes the player able to go right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontal * PlayerSpeed * Time.deltaTime);
        }
    }

    void PlayerMovementLeft()
    {
        // makes the player able to go left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.left * -horizontal * PlayerSpeed * Time.deltaTime);
        }
    }

    void PlayerMovementUp()
    {
        //  makes the player jump
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * vertical * PlayerSpeed * Time.deltaTime);
        }
    }

    void RaycastBottom()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  First time when spacebar is pressed
            if(pickedUp == false)
            {
                PickUpObject();
            }

            //  second time spacebar is pressed
            else if(pickedUp == true)
            {
                ShootObject();
            }
            
        }
    }

    void PickUpObject()
    {
        Debug.Log(" First time Spacebar");
        Vector2 raycastposition = new Vector2(transform.position.x, transform.position.y - 0.5f);

        RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.down, 40);

        Debug.DrawRay(raycastposition, Vector2.down, Color.red, 5);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Ground")    //  it works but it hits the player first
            {
                GameObject other = hit.collider.gameObject;

                PickedObject = other.gameObject;
                pickedUp = true;

            }
        }
    }

    void ShootObject()
    {
        Debug.Log("second time spacebar");
        Rigidbody2D rb;

        rb = PickedObject.AddComponent<Rigidbody2D>();  // Tom already has  a rigidbody
        PickedObject.AddComponent<PickedObjectScript>();

        rb.AddForce(transform.right * 50);
        pickedUp = false;
    }
}
