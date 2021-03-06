﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastScript : MonoBehaviour {

    [SerializeField]
    static public bool isThrown = false;

    private List<GameObject> childrenList;

    private GameObject ObjectInHand;
    private GameObject pickedObject;
    private GameObject referenceExamplePutDown;
    private GameObject arrow;
    private GameObject child;

    private Transform aimingArrowTransform;

    private Vector2 ObjectPointP1;    // the point where the picked-up block goes to
    private Vector2 ObjectPointP2;
    private Vector2 ObjectPointP3;
    private Vector2 ObjectPointP4;

    private Vector2 objectInHandPosition;

    private Vector2 putDownPoint;   // the point before the player where the block can be putt down
    private Vector2 raycastposition;    //  the position from where the ray is cast

    // positions adding object to pickedUpObject
    private Vector2 addedObjectPosition_1;
    private Vector2 addedObjectPosition_2;
    private Vector2 addedObjectPosition_3;
    private Vector2 addedObjectPosition_4;
    private Vector2 addedObjectPosition_5;
    private Vector2 addedObjectPosition_6;
    private Vector2 addedObjectPosition_7;
    private Vector2 addedObjectPosition_8;

    private float distanceFromPlayer = 4.0f;
    private float throwForce = 2000.0f;
    private float rayLength = 4;

    private float lenghtFromPlayerHorizontal = 0.2f;
    private float heightBlockPutDown = 0.8f;
    private float distanceBlockPutDown = 2.0f;

    private Rigidbody2D rigidbodyObjectInHand;

    private float pickupInput;
    private float throwInput;
    private float throwDirectionInputHorizontal;
    private float throwDirectionInputVertical;

    private int raycastIncrement = 1;

    private MovingScript movingScriptVariable;

    private KeyCode pickAndThrowInput;
    private KeyCode LB_Button;
    private KeyCode RB_Button;
    
    private bool isGrounded;
    private bool goingRight;
    private bool readyToAdd;
    private bool pickedUp = false;
    private bool puttingItDown = false;
    private bool buttonPlacementBool = false;
    private bool boolLB_Button = false;

    private string originalTag;

    private ParticleManagerScript particleManager;

    [SerializeField]
    private GameObject particleManagerObject;


    void Start()
    {
        raycastposition = new Vector2(transform.position.x, transform.position.y - 0.5f);

        particleManager = particleManagerObject.GetComponent<ParticleManagerScript>();

        arrow = gameObject.transform.GetChild(0).gameObject;
        child = gameObject.transform.GetChild(1).gameObject;
        child.SetActive(false);
        ObjectInHand = gameObject.transform.FindChild("ObjectInHand").gameObject;

        childrenList = new List<GameObject>();
    }

	// Update is called once per frame
	void Update () {
        isGrounded = this.GetComponent<MovingScript>().isGrounded;  // checks if the player is on the surface
        goingRight = this.GetComponent<MovingScript>().goingRight;  // gets the variable from the movingscript and checks the direction of the player

        if(puttingItDown == true){ ObjectInHand.transform.position = putDownPoint;}
        
        if (pickupInput <= 0.0f){readyToAdd = true;}

        GetAxis();
        RaycastBottom();
        SettingPoints();
        CheckPickedUp();
        RotateRaycastPlacement();
        PickAndAddGameObject();
    }

    private void GetAxis()
    {
        if (this.gameObject.tag == "Player")
        {
            pickupInput = Input.GetAxis("Joystick1Pickup");
            throwInput = Input.GetAxis("Joystick1Throw");
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player1");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player1");
            LB_Button = KeyCode.Joystick1Button4;
            RB_Button = KeyCode.Joystick1Button5;    
        }
        else if (this.gameObject.tag == "Player2")
        {
            pickupInput = Input.GetAxis("Joystick2Pickup");
            throwInput = Input.GetAxis("Joystick2Throw");
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player2");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player2");
            LB_Button = KeyCode.Joystick2Button4;
            RB_Button = KeyCode.Joystick2Button5;
        }
        else if (this.gameObject.tag == "Player3")
        {
            pickupInput = Input.GetAxis("Joystick3Pickup");
            throwInput = Input.GetAxis("Joystick3Throw");
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player3");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player3");
            LB_Button = KeyCode.Joystick3Button4;
            RB_Button = KeyCode.Joystick3Button5;
        }
        else if (this.gameObject.tag == "Player4")
        {
            pickupInput = Input.GetAxis("Joystick4Pickup");
            throwInput = Input.GetAxis("Joystick4Throw");
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player4");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player4");
            LB_Button = KeyCode.Joystick4Button4;
            RB_Button = KeyCode.Joystick4Button5;
        }

    }

    void CheckPickedUp()
    {
        if (pickedUp == true && this.gameObject.tag == "Player")
        {
            ObjectInHand.transform.position = ObjectPointP1;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player2")
        {
            ObjectInHand.transform.position = ObjectPointP2;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player3")
        {
            ObjectInHand.transform.position = ObjectPointP3;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player4")
        {
            ObjectInHand.transform.position = ObjectPointP4;
        }
    }
    
    void SettingPoints()
    {
        ObjectPointP1 = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer);
        ObjectPointP2 = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer);
        ObjectPointP3 = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer);
        ObjectPointP4 = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer);

        if (pickedUp == true && this.gameObject.tag == "Player")
        {
            objectInHandPosition = ObjectPointP1;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player2")
        {
            objectInHandPosition = ObjectPointP2;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player3")
        {
            objectInHandPosition = ObjectPointP3;
        }
        else if (pickedUp == true && this.gameObject.tag == "Player4")
        {
            objectInHandPosition = ObjectPointP4;
        }
        

        if ((ObjectPointP1 == objectInHandPosition) || (ObjectPointP2 == objectInHandPosition) || (ObjectPointP3 == objectInHandPosition) || (ObjectPointP4 == objectInHandPosition))
        {
            addedObjectPosition_1 = new Vector2(ObjectInHand.transform.position.x, ObjectInHand.transform.position.y - 1);  //  right under the parent
            addedObjectPosition_2 = new Vector2(ObjectInHand.transform.position.x - 1, ObjectInHand.transform.position.y - 1);  // bottom left of the parent
            addedObjectPosition_3 = new Vector2(ObjectInHand.transform.position.x + 1, ObjectInHand.transform.position.y - 1);  //  bottom right of the parent
            addedObjectPosition_4 = new Vector2(ObjectInHand.transform.position.x - 1, ObjectInHand.transform.position.y);  //  left of the parent
            addedObjectPosition_5 = new Vector2(ObjectInHand.transform.position.x + 1, ObjectInHand.transform.position.y);  //  right of the parent
            addedObjectPosition_6 = new Vector2(ObjectInHand.transform.position.x, ObjectInHand.transform.position.y + 1);  //  top of the parent
            addedObjectPosition_7 = new Vector2(ObjectInHand.transform.position.x - 1, ObjectInHand.transform.position.y + 1);  //  top left of the parent
            addedObjectPosition_8 = new Vector2(ObjectInHand.transform.position.x + 1, ObjectInHand.transform.position.y + 1);  //  top right of the parent
        }
    }

    void RaycastBottom()
    {
        Vector2 aimInput = new Vector2(throwDirectionInputHorizontal, throwDirectionInputVertical);
        Vector2 zeroInput = new Vector2(0, 0);

        if (pickedUp == true && aimInput != zeroInput)
        {
            arrow.SetActive(true);
        }
        else if (aimInput == zeroInput)
        {
            arrow.SetActive(false);
        }

        if (pickedUp == false && pickupInput >= 0.5f && throwInput == 0.0f && boolLB_Button==false)
        {

              PickUpObject();
        }

        else if (pickedUp == true && throwInput >= 0.5f && pickupInput == 0.0f && boolLB_Button==false)
        {
            ShootObject();
            isThrown = true;
        }
    }

    void PickUpObject()
    {
        GetComponent<PlayerStats>().StopRedFlashing();

        Vector2 raycastposition = new Vector2(transform.position.x, transform.position.y - 1.5f);
        RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.down, rayLength);

        if (hit.collider != null)
        {
            if (isGrounded && (hit.collider.gameObject.tag == "Dirt" || 
                    hit.collider.gameObject.tag == "Stone" ||
                    hit.collider.gameObject.tag == "Cloud" ||
                    hit.collider.gameObject.tag == "Wood"  ||
                    hit.collider.gameObject.tag == "PlacedObject" ||
                    hit.collider.gameObject.tag == "Barrel"))    //  it works but it hits the player first
            {
                GameObject other = hit.collider.gameObject;
                ObjectInHand = other.gameObject;

                originalTag = other.tag;
                other.tag = "PickedUpObject";
                pickedUp = true;

                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
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

        Debug.DrawRay(raycastposition, Vector2.down, Color.red, 5);
    }

    void ShootObject()
    {
        particleManager.SpawnSmallSpark(ObjectInHand.transform.position);

        Vector2 throwInput = new Vector2(throwDirectionInputHorizontal, throwDirectionInputVertical);

        ObjectInHand.GetComponent<BoxCollider2D>().enabled = true;

        int childrenAmount = childrenList.Count;

        for (int i = 0; i <= childrenAmount - 1; i++)
        {
            ObjectInHand.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;

            ObjectInHand.transform.GetChild(i).GetComponent<Rigidbody2D>().isKinematic = false;
            
        }

        rigidbodyObjectInHand = ObjectInHand.GetComponent<Rigidbody2D>();  // Tom already has  a rigidbody
        rigidbodyObjectInHand.isKinematic = false;

        rigidbodyObjectInHand.AddForce(throwInput.normalized * throwForce);

        for (int i = 0; i <= childrenAmount - 1; i++)
        {
            ObjectInHand.transform.GetChild(i).GetComponent<Rigidbody2D>().AddForce(throwInput.normalized * throwForce);

            childrenList.Clear();
        }
           



        rigidbodyObjectInHand = null;
        pickedUp = false;
        raycastIncrement = 1;

        // looping through the children of the object
        foreach (GameObject child in childrenList)
        {
            child.GetComponent<Rigidbody2D>().AddForce(throwInput.normalized * throwForce);
            child.GetComponent<Rigidbody2D>().isKinematic = false;
        }

        arrow.SetActive(false);

    }

    void RotateRaycastPlacement()
    {
        Vector2 throwInput = new Vector2(throwDirectionInputHorizontal, throwDirectionInputVertical);

        float angle = Mathf.Atan2(throwDirectionInputVertical, throwDirectionInputHorizontal);

        Ray ray = new Ray(transform.position, new Vector2(throwInput.x, throwInput.y)); //   TODO

        //  chooses where to place the object
        if (Input.GetKeyDown(RB_Button))
        {
            buttonPlacementBool = true;

            //  Sets the object placement active so it can be used
            child.SetActive(true);
        }

        /*
        * Shoots raycast and if it hits one of the placement colliders.
        * the picked-up object position = placement position\
        */
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            //  button down
            if (buttonPlacementBool == true && hit.collider.CompareTag("Placement") && pickedUp == true && isThrown == false)
            {
                arrow.SetActive(false);
                
                ObjectInHand.transform.position = hit.collider.gameObject.transform.position;  //  puts the position on the cube placement position

                //  Placement who are already triggered can't be placed on. TODO
            }
        }

        //  places the object and destroys the reference to that objectby refering to an empty game object
        if (Input.GetKeyUp(RB_Button))
        {
            buttonPlacementBool = false;
            
            /*
            * Shoots raycast and if it hits one of the placement colliders. the picked-up object position = placement position
            * gets rid of the reference */
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                // button up
                if (buttonPlacementBool == false && hit.collider.CompareTag("Placement") && pickedUp == true && isThrown == false)
                {
                    ObjectInHand.transform.position = hit.collider.gameObject.transform.position;
                
                    pickedUp = false;   // without it the player can't pick up anything 
                    rigidbodyObjectInHand = ObjectInHand.GetComponent<Rigidbody2D>();
                    rigidbodyObjectInHand.isKinematic = true;

                    // check tag and change the tag back to its original
                    ObjectInHand.tag = originalTag;

                    // turns collisions back on
                    ObjectInHand.GetComponent<BoxCollider2D>().enabled = true;

                    int childrenAmount = childrenList.Count;

                    for (int i = 0; i <= childrenAmount -1; i++)
                    {
                        ObjectInHand.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
                        ObjectInHand.transform.GetChild(i).tag = "PlacedObject";

                        childrenList.Clear();
                    }

                    particleManager.SpawnAfterBurner(this.transform.position);
                    particleManager.SpawnAfterBurner(hit.transform.position);

                    /* TO DO
                    for (int i = 0; i < ObjectInHand.transform.GetChildCount(); i++)
                    {
                        GameObject Go = (GameObject)ObjectInHand.transform.GetChild(i);
                    }
                    */
                }
            }
            child.SetActive(false);
        }
    }

    void PickAndAddGameObject()
    {
        //if (Input.GetKeyDown(LB_Button)){
           // boolLB_Button = false; }
       // if (Input.GetKeyUp(LB_Button))
       // {
         //   boolLB_Button = true;}

        if (pickedUp == true && throwInput == 0.0f && Input.GetKeyUp(LB_Button) && readyToAdd == true && raycastIncrement <9)
        {
            // raycast down
            Vector2 raycastposition = new Vector2(transform.position.x, transform.position.y - 1.5f);
            RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.down, rayLength);

            if (hit.collider != null)
            {
                if (isGrounded && (hit.collider.gameObject.tag == "Dirt" ||
                                   hit.collider.gameObject.tag == "Stone" ||
                                   hit.collider.gameObject.tag == "Cloud" ||
                                   hit.collider.gameObject.tag == "Wood" ||
                                   hit.collider.gameObject.tag == "Barrel"))    //  it works but it hits the player first
                {
                    GameObject other = hit.collider.gameObject;
                    other.transform.parent = ObjectInHand.transform;
                    
                    originalTag = other.tag;
                    other.tag = "PickedUpObject";
                    other.GetComponent<BoxCollider2D>().enabled = false;

                    if (raycastIncrement == 1){ other.transform.position = addedObjectPosition_1; }
                    if (raycastIncrement == 2){ other.transform.position = addedObjectPosition_2; }
                    if (raycastIncrement == 3){ other.transform.position = addedObjectPosition_3; }
                    if (raycastIncrement == 4){ other.transform.position = addedObjectPosition_4; }
                    if (raycastIncrement == 5){ other.transform.position = addedObjectPosition_5; }
                    if (raycastIncrement == 6){ other.transform.position = addedObjectPosition_6; }
                    if (raycastIncrement == 7){ other.transform.position = addedObjectPosition_7; }
                    if (raycastIncrement == 8){ other.transform.position = addedObjectPosition_8; }

                    
                    raycastIncrement++;
                    readyToAdd = false;
                    //   add it to the array
                    childrenList.Add(other);

                }
            }
            // add object to to ObjectAtHand
            //  Make it a child of ObjectAtHand
            Debug.Log("pickign up and adding");
        }
        //
        //this.transform.parent = yourParentObject;
        //  pickUpAndAdd.transform.position = objectAddPosition1
        //  Game object = Gameobject + pickUpAndAddObject
    }
}
