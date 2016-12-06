using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

    public GameObject player;
    public bool isGrounded = false;

    private float PlayerSpeed = 10;
    private int jumpPower = 500;
    private bool goingRight = true;

    private KeyCode leftInput;
    private KeyCode rightInput;
    private KeyCode jumpInput;

    private string horizontalAxis;
    private string verticalAxis;

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
            verticalAxis = "VerticalPlayer1";
        }
        else if (this.gameObject.tag == "Player2")
        {
            leftInput = KeyCode.A;
            rightInput = KeyCode.D;
            jumpInput = KeyCode.W;

            horizontalAxis = "HorizontalPlayer2";
            verticalAxis = "VerticalPlayer2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementLeft();
        PlayerMovementRight();
        PlayerMovementUp();
        RotateCharacter();
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
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(goingRight == false)
        {
            // make the character look to the left
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void PlayerMovementRight()
    {
        //  makes the player able to go right
        if (Input.GetKey(rightInput))
        {
            float horizontal = Input.GetAxis(horizontalAxis);
            player.transform.Translate(Vector2.right * horizontal * PlayerSpeed * Time.deltaTime);

            goingRight = true;
        }
    }

    void PlayerMovementLeft()
    {
        // makes the player able to go left
        if (Input.GetKey(leftInput))
        {
            float horizontal = Input.GetAxis(horizontalAxis);
            player.transform.Translate(Vector2.left * horizontal * PlayerSpeed * Time.deltaTime);

            goingRight = false;
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
