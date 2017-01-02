using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

    private float throwDirectionInputHorizontal;
    private float throwDirectionInputVertical;

    private GameObject player;

    // Use this for initialization
    void Start ()
    {
        gameObject.SetActive(false);

        player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {

        GetInput();

        RotateArrowAroundPlayer();

    }

    void GetInput()
    {
        if (gameObject.transform.parent.tag == "Player")
        {
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player1");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player1");
        }
        if (gameObject.transform.parent.tag == "Player2")
        {
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player2");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player2");
        }
        if (gameObject.transform.parent.tag == "Player3")
        {
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player3");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player3");
        }
        if (gameObject.transform.parent.tag == "Player4")
        {
            throwDirectionInputHorizontal = Input.GetAxis("Horizontal2Player4");
            throwDirectionInputVertical = Input.GetAxis("Vertical2Player4");
        }

    }

    void RotateArrowAroundPlayer()
    {
        Vector2 throwInput = new Vector2(throwDirectionInputHorizontal, throwDirectionInputVertical);

        float angle = Mathf.Atan2(throwDirectionInputVertical, throwDirectionInputHorizontal);

        //gameObject.transform.LookAt(throwInput);
        //gameObject.transform.RotateAround(player.transform.position,  throwInput, 5.0f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }
}
