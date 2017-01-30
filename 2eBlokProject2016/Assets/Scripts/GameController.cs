using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    PlayerStats playerStats;

    public bool gameOver = false;

    public bool player1Active = true;
    public bool player2Active = true;
    public bool player3Active = true;
    public bool player4Active = true;

    public bool team1Win = false;
    public bool team2Win = false;

    [SerializeField]
    private Camera cameraTeam1;

    [SerializeField]
    private Camera cameraTeam2;

    [SerializeField]
    private Camera endCamera;


	// Use this for initialization
	void Start ()
    {
        playerStats = GetComponent<PlayerStats>();

        endCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player1Active == false && player2Active == false)
        {
            team2Win = true;
            gameOver = true;
        }
        else if (player3Active == false && player4Active == false)
        {
            team1Win = true;
            gameOver = true;
        }

        CameraPanOut();
	}


    void CameraPanOut()
    {
        

        if (gameOver)
        {
            cameraTeam1.enabled = false;
            cameraTeam2.enabled = false;

            endCamera.enabled = true;
        }

    }
}
