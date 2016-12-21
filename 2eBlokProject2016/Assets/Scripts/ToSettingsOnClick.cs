using UnityEngine;
using System.Collections;

public class ToSettingsOnClick : MonoBehaviour {

    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

	public void ToSettings ()
    {

            mainMenuPanel.SetActive(false);

            settingsPanel.SetActive(true);
	}
}
