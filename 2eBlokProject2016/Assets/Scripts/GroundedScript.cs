using UnityEngine;
using System.Collections;

public class GroundedScript : MonoBehaviour {

    private MovingScript player;

    void Start()
    {
        player = transform.parent.GetComponent<MovingScript>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        player.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.isGrounded = false;
    }
}
