using UnityEngine;
using System.Collections;

public class ActionMovementScript : MonoBehaviour {

    public GameObject leftBox;
    public GameObject rightBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        InputPlayer();
	}

    void InputPlayer()
    {
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.B))
        {
            leftBox.SetActive(true);
            rightBox.SetActive(true);
        }
        else
        {
            leftBox.SetActive(false);
            rightBox.SetActive(false);
        }
    }
}
