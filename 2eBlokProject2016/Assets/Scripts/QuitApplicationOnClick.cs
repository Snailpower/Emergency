using UnityEngine;
using System.Collections;

public class QuitApplicationOnClick : MonoBehaviour {

	public void QuitApplication()
    {
        Debug.Log("Quit");

        Application.Quit();
    }
}
