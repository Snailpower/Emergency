using UnityEngine;
using System.Collections;

public class ToMainMenuOnClick : MonoBehaviour {

    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    public void ToMainMenu()
    {
            settingsPanel.SetActive(false);

            mainMenuPanel.SetActive(true);
    }
}
