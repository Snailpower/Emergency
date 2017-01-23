using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinText : MonoBehaviour {

    private Canvas canvas;

    [SerializeField]
    private GameObject text;

    [SerializeField]
    private GameObject gameController;

    GameController gameControllerScript;

    Text winText;

	// Use this for initialization
	void Start () {
        gameControllerScript = gameController.GetComponent<GameController>();
        winText = text.GetComponent<Text>();

        canvas = gameObject.GetComponent<Canvas>();

        canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameControllerScript.gameOver == true)
        {
            canvas.enabled = true;

            Debug.Log("Game Over");
        }

        if (gameControllerScript.team1Win == true)
        {
            winText.text = "Team 1 Wins!";
        }
        else if (gameControllerScript.team2Win == true)
        {
            winText.text = "Team 2 Wins!";
        }
	}
}
