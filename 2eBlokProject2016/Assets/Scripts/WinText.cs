using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinText : MonoBehaviour {

    GameController gameController;

    Text winText;

	// Use this for initialization
	void Start () {
        gameController = GetComponent<GameController>();
        winText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameController.team1Win == true)
        {
            winText.text = "Team 1 Wins!";
        }
        else if (gameController.team2Win == true)
        {
            winText.text = "Team 2 Wins!";
        }
	}
}
