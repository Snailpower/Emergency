using UnityEngine;
using System.Collections;

public class GroundedScript : MonoBehaviour {

    public MovingScript player;

    void OnTriggerEnter2D(Collider2D other)
    {
        player.isGrounded = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        player.isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        player.isGrounded = false;
    }
}
