using UnityEngine;
using System.Collections;

public class PickedObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        DestroyObject(other.gameObject, 0.01f);
        DestroyObject(this.gameObject, 0.01f);
    }
}
