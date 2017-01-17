using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int playerHP = 20;

    public GameObject gameController;

    private GameController gameControllerScript;

    // Use this for initialization
    void Start ()
    {
        gameControllerScript = gameController.GetComponent<GameController>();
	}
	
	//Update is called once per frame
	void Update () {

        if (playerHP <= 0)
        {
            if (gameObject.tag == "Player")
            {
                gameControllerScript.player1Active = false;

                
            }
            else if (gameObject.tag == "Player2")
            {
                gameControllerScript.player2Active = false;

                
            }
            else if (gameObject.tag == "Player3")
            {
                gameControllerScript.player3Active = false;

                
            }
            else if (gameObject.tag == "Player4")
            {
                gameControllerScript.player4Active = false;

                
            }

        }
        


	}
}
