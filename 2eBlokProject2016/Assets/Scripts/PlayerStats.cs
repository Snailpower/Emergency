using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int playerCurrentHP;

    [SerializeField]
    private int startingHP = 20;

    public GameObject gameController;

    public Slider healthSlider;

    private GameController gameControllerScript;

    private bool damaged = false;

    [SerializeField]
    private float damageCoolDown = 1f;

    // Use this for initialization
    void Start ()
    {

        playerCurrentHP = startingHP;
        
        gameControllerScript = gameController.GetComponent<GameController>();
	}
	
	//Update is called once per frame
	void Update () {

        if (damaged)
        {
            damageCoolDown -= Time.deltaTime;
            if (damageCoolDown <= 0)
            {
                damaged = false;
                damageCoolDown = 1f;

            }
        }
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        StartRedFlashing();
        playerCurrentHP -= amount;

        healthSlider.value = playerCurrentHP;

        if (playerCurrentHP <= 0)
        {
            PlayerStatus();
        }

    }

    public void PlayerStatus()
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

    void StartRedFlashing()
    {
        StartCoroutine(RedFlashingCharacter());
    }

    public void StopRedFlashing()
    {
        StopCoroutine("StartRedFlashing");
        GetComponentInChildren<Renderer>().material.color = Color.white;
    }

    IEnumerator RedFlashingCharacter()
    {
        GetComponentInChildren<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponentInChildren<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        GetComponentInChildren<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponentInChildren<Renderer>().material.color = Color.white;
    }
}


