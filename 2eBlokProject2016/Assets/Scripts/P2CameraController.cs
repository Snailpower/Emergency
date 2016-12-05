using UnityEngine;
using System.Collections;

public class P2CameraController : MonoBehaviour {

    public GameObject player2;

    [SerializeField]
    private int cameraYOffset = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(player2.transform.position.x, (player2.transform.position.y + cameraYOffset), -10);
    }
}
