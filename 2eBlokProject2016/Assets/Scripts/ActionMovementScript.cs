using UnityEngine;
using System.Collections;

public class ActionMovementScript : MonoBehaviour {

    public GameObject leftBox;
    public GameObject rightBox;
    public GameObject pickUpColliderObject;

    private KeyCode digButton;
    private KeyCode pickAndThrowInput;
    private bool isThrown = false;

    // Use this for initialization
    void Start () {
        if (this.gameObject.tag == "Player")
        {
            digButton = KeyCode.B;
            pickAndThrowInput = KeyCode.Space;
        }
        else if (this.gameObject.tag == "Player2")
        {
            digButton = KeyCode.Alpha2;
            pickAndThrowInput = KeyCode.Alpha1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        InputPlayer();
	}

    void InputPlayer()
    {
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(digButton))
        {
            leftBox.SetActive(true);
            rightBox.SetActive(true);
        }
        else
        {
            leftBox.SetActive(false);
            rightBox.SetActive(false);
        }

        if(Input.GetKeyDown(pickAndThrowInput))
        {
            if(isThrown == false)
            {
                //pickUpColliderObject.SetActive(true);
            }
            
        }
    }
}
