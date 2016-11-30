using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {
    
    private float PlayerSpeed = 10;
    private bool goingRight = true;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementLeft();
        PlayerMovementRight();
        PlayerMovementUp();
        RotateCharacter();
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontal * PlayerSpeed * Time.deltaTime);

            goingRight = true;
        }
    }

    void PlayerMovementLeft()
    {
        // makes the player able to go left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.left * horizontal * PlayerSpeed * Time.deltaTime);

            goingRight = false;
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
}
