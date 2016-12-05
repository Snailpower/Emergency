using UnityEngine;
using System.Collections;

public class P1CameraController : MonoBehaviour {

    public GameObject player1;

    [SerializeField]
    private int cameraYOffset = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(player1.transform.position.x, (player1.transform.position.y + cameraYOffset), -10);
	}
}
