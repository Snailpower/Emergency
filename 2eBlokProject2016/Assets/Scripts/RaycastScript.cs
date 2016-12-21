using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour {

    static public bool isThrown = false;

    private bool pickedUp = false;

    private GameObject PickedObject;

    private GameObject arrow;

    private Transform aimingArrowTransform;

    private Vector2 ObjectPoint;    // the point where the picked-up block goes to

    private float distanceFromPlayer = 4.0f;
    private float throwForce = 2000.0f;
    private float rayLength = 100;
    private float lenghtFromPlayerHorizontal = 0.2f;
    private float lengthFromPlayerDigging = 0.5f;

    private Rigidbody2D rigidbodyPickedObject;

    private float pickupInput;
    private float throwInput;
    private float throwDirectionInputHorizontal;
    private float throwDirectionInputVertical;
    
    void Start()
    {
        arrow = gameObject.transform.GetChild(0).gameObject;

    }

	// Update is called once per frame
	void Update ()
    {
        GetAxis();

        RaycastBottom();
        SettingPoints();
        CheckPickedUp();
    }

    private void GetAxis()
    {
        if (this.gameObject.tag == "Player")
        {
            pickupInput = Input.GetAxis("Joystick1Pickup");
            throwInput = Input.GetAxis("Joystick1Throw");
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player1");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player1");

            Debug.Log("pickedUp " + pickedUp);
            Debug.Log("LT AXIS " + pickupInput);
            Debug.Log("RT AXIS " + throwInput);
        }
        else if (this.gameObject.tag == "Player2")
        {
            pickupInput = Input.GetAxis("Joystick2Pickup");
            throwInput = Input.GetAxis("Joystick2Throw");
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player2");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player2");
        }
        else if (this.gameObject.tag == "Player3")
        {
            pickupInput = Input.GetAxis("Joystick3Pickup");
            throwInput = Input.GetAxis("Joystick3Throw");
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player3");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player3");
        }
        else if (this.gameObject.tag == "Player4")
        {
            pickupInput = Input.GetAxis("Joystick4Pickup");
            throwInput = Input.GetAxis("Joystick4Throw");
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player4");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player4");
        }
    }

    void CheckPickedUp()
    {
        if (pickedUp == true && this.gameObject.tag == "Player")
        {
            PickedObject.transform.position = ObjectPoint;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player2")
        {
            PickedObject.transform.position = ObjectPoint;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player3")
        {
            PickedObject.transform.position = ObjectPoint;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player4")
        {
            PickedObject.transform.position = ObjectPoint;
        }
    }
    
    void SettingPoints()
    {
        ObjectPoint = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer);
    }



    void RaycastBottom()
    {
        if (pickedUp == true)
        {
            arrow.SetActive(true);
        }


        if (pickedUp == false && pickupInput >= 0.5f && throwInput == 0.0f)
        {
              PickUpObject();
        }

        //  second time spacebar is pressed
        else if (pickedUp == true && throwInput >= 0.5f && pickupInput == 0.0f)
        {
            ShootObject();
            Debug.Log("Object is being thrown");
            isThrown = true;
            arrow.SetActive(false);
        }

    }

    void PickUpObject()
    {
        Vector2 raycastposition = new Vector2(transform.position.x, transform.position.y - 0.5f);

        RaycastHit2D hit;

        if (hit = Physics2D.Raycast(raycastposition, Vector2.down, 2.0f))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.tag);

                if (hit.collider.gameObject.tag == "Dirt" || hit.collider.gameObject.tag == "Stone" || hit.collider.gameObject.tag == "Cloud")    //  it works but it hits the player first
                {
                    GameObject other = hit.collider.gameObject;

                    PickedObject = other.gameObject;

                    other.tag = "PickedUpObject";

                    pickedUp = true;
                }
            }
        }

        Debug.DrawRay(raycastposition, Vector2.down, Color.red, 5);
    }

    void ShootObject()
    {
        Vector2 throwInput = new Vector2(throwDirectionInputHorizontal, throwDirectionInputVertical);


        rigidbodyPickedObject = PickedObject.GetComponent<Rigidbody2D>();  // Tom already has  a rigidbody
        rigidbodyPickedObject.isKinematic = false;

        rigidbodyPickedObject.AddForce(throwInput.normalized * throwForce);

        Debug.Log("Horizontal" + throwDirectionInputHorizontal + "Vertical" + throwDirectionInputVertical);

        pickedUp = false;
    }


}
