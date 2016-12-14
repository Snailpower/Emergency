using UnityEngine;
using System.Collections;

public class CheckBoxScript : MonoBehaviour {

    private Vector2 diggingObjectPointLeft; // digging down left raycast use this point
    private Vector2 diggingObjectPointRight;    //  digging down right raycast use this point


    void OnCollisionEnter2D(Collision2D other)
    {
        diggingObjectPointLeft = new Vector2(this.transform.position.x, this.transform.position.y + 10);
        other.transform.position = diggingObjectPointLeft;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.up * 2) + Vector2.right * 4);
    }
}
