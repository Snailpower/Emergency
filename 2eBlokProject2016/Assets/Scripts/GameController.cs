using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    PlayerStats playerStats;

    public bool player1Active = true;
    public bool player2Active = true;
    public bool player3Active = true;
    public bool player4Active = true;

    public bool team1Win = false;
    public bool team2Win = false;

	// Use this for initialization
	void Start ()
    {
        playerStats = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player1Active == false && player2Active == false)
        {
            SceneManager.LoadScene("EndScene");
            team2Win = true;
        }
        else if (player3Active == false && player4Active == false)
        {
            SceneManager.LoadScene("EndScene");
            team1Win = true;
        }
	}
}
