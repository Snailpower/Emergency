using UnityEngine;
using System.Collections;

public class P1CameraController : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    [SerializeField]
    private int cameraYOffset = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = new Vector3(((player1.transform.position.x + player2.transform.position.x) / 2), (((player1.transform.position.y + player2.transform.position.y) / 2) + cameraYOffset), -20);

	}
}
