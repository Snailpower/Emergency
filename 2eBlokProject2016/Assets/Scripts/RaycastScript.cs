using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour {

    private bool pickedUp = false;

    private GameObject PickedObject;

    private Vector2 ObjectPoint;

    private float distanceFromPlayer = 2.0f;
    private float throwForce = 2000.0f;

    private Rigidbody2D rigidbodyPickedObject;
    
	// Update is called once per frame
	void Update () {
        ObjectPoint = new Vector2(transform.position.x, transform.position.y + distanceFromPlayer);

        if (pickedUp == true)
        {
            PickedObject.transform.position = ObjectPoint;
        }
    }

    void FixedUpdate() {
        RaycastBottom();

    }

    void RaycastBottom()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  First time when spacebar is pressed
            if (pickedUp == false) {
                PickUpObject();
            }

            //  second time spacebar is pressed
            else if (pickedUp == true) {
                ShootObject();
            }
        }
    }

    void PickUpObject()
    {
        Vector2 raycastposition = new Vector2(transform.position.x, transform.position.y - 0.5f);

        RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.down, 40);

        Debug.DrawRay(raycastposition, Vector2.down, Color.red, 5);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Ground")    //  it works but it hits the player first
            {
                GameObject other = hit.collider.gameObject;

                PickedObject = other.gameObject;
                pickedUp = true;
            }
        }
    }

    void ShootObject()
    {
        rigidbodyPickedObject = PickedObject.GetComponent<Rigidbody2D>();  // Tom already has  a rigidbody
        rigidbodyPickedObject.isKinematic = false;
        PickedObject.AddComponent<PickedObjectScript>();

        rigidbodyPickedObject.AddForce(transform.right * throwForce);
        pickedUp = false;
    }
}
