using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

    public GameObject player;
    public bool isGrounded = false;


    private float increaserSpeed;
    private float startSpeed = 1.0f;
    private float addingSpeed = 0.1f;
    private float maxSpeed = 1.5f;
    private bool isSpeeding = false;

    private float PlayerSpeed = 10;
    private int jumpPower = 2000;
    public bool goingRight = true;

    private KeyCode leftInput;
    private KeyCode rightInput;
    private KeyCode jumpInput;

    private string horizontalAxis;

    private Rigidbody2D playerRigidbody;

    // Use this for initialization
    void Start () {
        AssignRightInputToPlayer();

        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }

    void AssignRightInputToPlayer()
    {
        if (this.gameObject.tag == "Player")
        {
            leftInput = KeyCode.LeftArrow;
            rightInput = KeyCode.RightArrow;
            jumpInput = KeyCode.UpArrow;

            horizontalAxis = "HorizontalPlayer1";
        }
        else if (this.gameObject.tag == "Player2")
        {
            leftInput = KeyCode.A;
            rightInput = KeyCode.D;
            jumpInput = KeyCode.W;

            horizontalAxis = "HorizontalPlayer2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeeding == true)
        {
            increaserSpeed += addingSpeed;
        }   else if (isSpeeding == false)
        {
            increaserSpeed = startSpeed;
        }

        if(playerRigidbody.velocity.x > -0.1f && playerRigidbody.velocity.x < 0.1f)
        {
            isSpeeding = false;
        }

        if( increaserSpeed > maxSpeed)
        {
            increaserSpeed = maxSpeed;
        }

        PlayerMovementLeft();
        PlayerMovementRight();
        PlayerMovementUp();
        RotateCharacter();
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

    void OnCollisionEnter2D()
    {
        isGrounded = true;
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
        if (Input.GetKey(rightInput))
        {
            float horizontal = Input.GetAxis(horizontalAxis);
            player.transform.Translate(Vector2.right * horizontal * PlayerSpeed * Time.deltaTime * increaserSpeed);

            goingRight = true;
            isSpeeding = true;
        }
    }

    void PlayerMovementLeft()
    {
        // makes the player able to go left
        if (Input.GetKey(leftInput))
        {
            float horizontal = Input.GetAxis(horizontalAxis);
            player.transform.Translate(Vector2.left * horizontal * PlayerSpeed * Time.deltaTime * increaserSpeed);

            goingRight = false;
            isSpeeding = true;
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
