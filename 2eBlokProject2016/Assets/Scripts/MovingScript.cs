﻿using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

    public GameObject player;
    public bool isGrounded = false;

    private float increaserSpeed;
    private float startSpeed = 1.0f;
    private float addingSpeed = 0.1f;
    private float maxSpeed = 1.5f;
    private float resetYPosition = 12f;
    private bool isSpeeding = false;
    private bool reseted = false;

    public Camera cameraT1;
    public Camera cameraT2;
    
    private float PlayerSpeed = 10;
    private int jumpPower = 1500;
    public bool goingRight = true;

    private KeyCode leftInput;
    private KeyCode rightInput;
    private KeyCode jumpInput;
    private KeyCode resetLocationInput;

    private float horizontalAxis;
    private float verticalAxis;

    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private GameObject playerModel;

    private Animator playerAnimator;

    // Use this for initialization
    void Start () {

        playerAnimator = playerModel.GetComponent<Animator>();

        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //  set the z position on 0 to prevent issues like getting in front or behind the level
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        ResetYPosition();

        AssignRightInputToPlayer();

        SpeedingCheck();

        if (this.gameObject.tag == "Player" || this.gameObject.tag == "Player2")
        {
            PlayerMovementLeft();
            PlayerMovementRight();
            PlayerMovementUp();
            RotateCharacter();
            CameraClampTeam1();
        }
        else if (this.gameObject.tag == "Player3" || this.gameObject.tag == "Player4")
        {
            PlayerMovementLeft();
            PlayerMovementRight();
            PlayerMovementUp();
            RotateCharacter();
            CameraClampTeam2();
        }
    }

    void CameraClampTeam1()
    {
        var posCamera1 = cameraT1.WorldToViewportPoint(transform.position);
        if (cameraT1.enabled == true)
        {

            posCamera1.x = Mathf.Clamp(posCamera1.x, 0.0f, 1.0f);
            posCamera1.y = Mathf.Clamp(posCamera1.y, 0.0f, 1.0f);
            transform.position = cameraT1.ViewportToWorldPoint(posCamera1);
        }
    }

    void CameraClampTeam2()
    {
        var posCamera2 = cameraT2.WorldToViewportPoint(transform.position);

        if (cameraT2.enabled == true)
        {

            posCamera2.x = Mathf.Clamp(posCamera2.x, 0.0f, 1.0f);
            posCamera2.y = Mathf.Clamp(posCamera2.y, 0.0f, 1.0f);
            transform.position = cameraT2.ViewportToWorldPoint(posCamera2);
        }
    }

    void SpeedingCheck()
    {
        if (isSpeeding == true)
        {
            increaserSpeed += addingSpeed;
        }
        else if (isSpeeding == false)
        {
            increaserSpeed = startSpeed;
        }

        if (playerRigidbody.velocity.x > -0.1f && playerRigidbody.velocity.x < 0.1f)
        {
            isSpeeding = false;
        }

        if (increaserSpeed > maxSpeed)
        {
            increaserSpeed = maxSpeed;
        }
    }

    void ResetYPosition()
    {
        if(Input.GetKeyUp(resetLocationInput)){
            reseted = true;
            isGrounded = false;
            transform.position = new Vector3(transform.position.x, resetYPosition, transform.position.z);
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if(isGrounded == true)
        {
            reseted = false;
            this.GetComponent<Rigidbody2D>().gravityScale = 10;
        }
        
    }

    void AssignRightInputToPlayer()
    {

        if (this.gameObject.tag == "Player")
        {
            /*leftInput = KeyCode.LeftArrow;
            rightInput = KeyCode.RightArrow;*/
            jumpInput = KeyCode.Joystick1Button0;
            resetLocationInput = KeyCode.Joystick1Button6;

            horizontalAxis = Input.GetAxisRaw("HorizontalPlayer1");
            verticalAxis = Input.GetAxisRaw("VerticalPlayer1");
        }
        else if (this.gameObject.tag == "Player2")
        {

            /*leftInput = KeyCode.A;
            rightInput = KeyCode.D;*/
            jumpInput = KeyCode.Joystick2Button0;
            resetLocationInput = KeyCode.Joystick2Button6;

            horizontalAxis = Input.GetAxisRaw("HorizontalPlayer2");
            verticalAxis = Input.GetAxisRaw("VerticalPlayer2");

        }
        else if (this.gameObject.tag == "Player3")
        {
            jumpInput = KeyCode.Joystick3Button0;
            resetLocationInput = KeyCode.Joystick3Button6;

            horizontalAxis = Input.GetAxisRaw("HorizontalPlayer3");
            verticalAxis = Input.GetAxisRaw("VerticalPlayer3");
        }
        else if (this.gameObject.tag == "Player4")
        {
            jumpInput = KeyCode.Joystick4Button0;
            resetLocationInput = KeyCode.Joystick4Button6;

            horizontalAxis = Input.GetAxisRaw("HorizontalPlayer4");
            verticalAxis = Input.GetAxisRaw("VerticalPlayer4");
        }
    }

    void FixedUpdate()
    {
        /*
        Vector3 easeVelocity = playerRigidbody.velocity;

        easeVelocity.y = playerRigidbody.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 10;

        // fakes friction - most noticable by start walking
        playerRigidbody.velocity = easeVelocity;
        */
    }

    void RotateCharacter()
    {
        if(goingRight == true)
        {
            //  make the character look to the right
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(goingRight == false)
        {
            // make the character look to the left
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void PlayerMovementRight()
    {
        //  makes the player able to go right
        float horizontal = horizontalAxis;

        if (horizontal > 0)
        {
            player.transform.Translate(Vector2.right * horizontal * PlayerSpeed * Time.deltaTime * increaserSpeed);

            playerAnimator.SetBool("IsWalking", true);

            goingRight = true;
            isSpeeding = true;
        }
        else if (horizontal == 0)
        {
            playerAnimator.SetBool("IsWalking", false);
        }
    }

    void PlayerMovementLeft()
    {
        // makes the player able to go left
        float horizontal = horizontalAxis;

        if (horizontal < 0)
        {
            player.transform.Translate(Vector2.left * horizontal * PlayerSpeed * Time.deltaTime * increaserSpeed);


            playerAnimator.SetBool("IsWalking", true);

            goingRight = false;
            isSpeeding = true;
        }
        else if (horizontal == 0)
        {
            playerAnimator.SetBool("IsWalking", false);
        }

    }

    void PlayerMovementUp()
    {
        //  makes the player jump if the player is grounded
        if (Input.GetKeyDown(jumpInput) && isGrounded == true)
        {
            playerRigidbody.AddForce(transform.up * jumpPower);
            isGrounded = false;
        }
    }
}
