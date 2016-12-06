using UnityEngine;
using System.Collections;

public class CheckBoxScript : MonoBehaviour {

    private Vector2 diggingObjectPointLeft; // digging down left raycast use this point
    private Vector2 diggingObjectPointRight;    //  digging down right raycast use this point

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        diggingObjectPointLeft = new Vector2(this.transform.position.x, this.transform.position.y + 3);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.position = diggingObjectPointLeft;
    }
}
